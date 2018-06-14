using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Kurs.Core.Domain;
using Kurs.Core.EntityActions;
using Microsoft.EntityFrameworkCore;

namespace Kurs.Core.Data
{
    public class EfRepository<TEntity> : IRepository<TEntity> 
        where TEntity : BaseEntity
    {
        private static readonly string ENTITY_NOT_FOUND = "Entity with id {0} not found.";

        private readonly IEntityActionsHandler<TEntity> _actionsHandler;

        protected DbSet<TEntity> DbSet => DbContext.Set<TEntity>();
        protected DbContext DbContext { get; }

        public IQueryable<TEntity> Entities => DbSet;

        public EfRepository(NotesContext dbContext, IEntityActionsHandler<TEntity> actionsHandler)
        {
            DbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _actionsHandler = actionsHandler ?? throw new ArgumentNullException(nameof(actionsHandler));
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            if (entity.Id == Guid.Empty)
            {
                entity.Id = Guid.NewGuid();
            }

            await _actionsHandler.OnCreatingAsync(entity);
            TEntity addedEntity = DbSet.Add(entity).Entity;
            await DbContext.SaveChangesAsync();
            await _actionsHandler.OnCreatedAsync(addedEntity);
            return addedEntity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            TEntity foundEntity;
            if (entity.Id != Guid.Empty && (foundEntity = DbSet.Find(entity.Id)) != null)
            {
                await _actionsHandler.OnUpdatingAsync(foundEntity, entity);
                CopyProperties(foundEntity, entity);
                foundEntity = DbSet.Update(foundEntity).Entity;
            }
            else
            {
                throw new ArgumentException(string.Format(ENTITY_NOT_FOUND, entity.Id), nameof(entity));
            }
            await DbContext.SaveChangesAsync();
            await _actionsHandler.OnUpdatedAsync(foundEntity, entity);
            return foundEntity;
        }

        public async Task DeleteAsync(object id)
        {
            TEntity entity = DbSet.Find(id);
            if (entity != null)
            {
                await _actionsHandler.OnDeletingAsync(entity);
                DbSet.Remove(entity);
                await DbContext.SaveChangesAsync();
                await _actionsHandler.OnDeletedAsync(entity);
            }
        }

        public async Task<TEntity> GetByIdAsync(object id) =>
            await DbSet.FindAsync(id);

        private void CopyProperties(TEntity destEntity, TEntity srcEntity)
        {
            foreach (PropertyInfo property in typeof(TEntity).GetProperties())
            {
                property.SetValue(destEntity, property.GetValue(srcEntity));
            }
        }
    }
}