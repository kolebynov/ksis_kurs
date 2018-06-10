using System.ComponentModel.DataAnnotations;

namespace Kurs.Core.Domain
{
    [DisplayColumn(nameof(Name))]
    public abstract class BaseLookup : BaseEntity
    {
        [MaxLength(250)]
        public virtual string Name { get; set; }
    }
}