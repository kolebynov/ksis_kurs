using System.ComponentModel.DataAnnotations;

namespace Kurs.Models
{
    public class GetItemsOptions
    {
        [Range(1, int.MaxValue)]
        public int Page { get; set; } = 1;

        [Range(0, int.MaxValue)]
        public int RowsCount { get; set; }
    }
}
