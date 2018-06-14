using System.Threading.Tasks;
using Kurs.Core.Domain;

namespace Kurs.Core.EntityActions
{
    public class DefaultEntityActionsHandler<TEntity> : IEntityActionsHandler<TEntity>
    {
        public virtual Task OnCreatingAsync(TEntity entity) => Task.CompletedTask;

        public virtual Task OnCreatedAsync(TEntity entity) => Task.CompletedTask;

        public virtual Task OnUpdatingAsync(TEntity oldEntity, TEntity newEntity) => Task.CompletedTask;

        public virtual Task OnUpdatedAsync(TEntity oldEntity, TEntity newEntity) => Task.CompletedTask;

        public virtual Task OnDeletingAsync(TEntity entity) => Task.CompletedTask;

        public virtual Task OnDeletedAsync(TEntity entity) => Task.CompletedTask;
    }
}