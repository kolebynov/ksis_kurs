using System.Threading.Tasks;
using Kurs.Core.Domain;

namespace Kurs.Core.EntityActions
{
    public interface IEntityActionsHandler<in TEntity>
    {
        Task OnCreatingAsync(TEntity entity);
        Task OnCreatedAsync(TEntity entity);
        Task OnUpdatingAsync(TEntity oldEntity, TEntity newEntity);
        Task OnUpdatedAsync(TEntity oldEntity, TEntity newEntity);
        Task OnDeletingAsync(TEntity entity);
        Task OnDeletedAsync(TEntity entity);
    }
}