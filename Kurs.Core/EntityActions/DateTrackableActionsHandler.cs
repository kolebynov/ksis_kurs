using System;
using System.Threading.Tasks;
using Kurs.Core.Domain;

namespace Kurs.Core.EntityActions
{
    public class DateTrackableActionsHandler : DefaultEntityActionsHandler<IDateTrackable>
    {
        public override Task OnCreatingAsync(IDateTrackable entity)
        {
            entity.CreatedOn = DateTime.UtcNow;
            entity.ModifiedOn = DateTime.UtcNow;
            return base.OnCreatingAsync(entity);
        }

        public override Task OnUpdatingAsync(IDateTrackable oldEntity, IDateTrackable newEntity)
        {
            newEntity.CreatedOn = oldEntity.CreatedOn;
            newEntity.ModifiedOn = DateTime.UtcNow;
            return base.OnUpdatingAsync(oldEntity, newEntity);
        }
    }
}