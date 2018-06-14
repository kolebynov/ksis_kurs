using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kurs.Core.Domain
{
    public class Note : BaseLookup, IDateTrackable
    {
        public DateTime CreatedOn { get; set; }

        public DateTime ModifiedOn { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        [ForeignKey(nameof(Category))]
        public Guid? CategoryId { get; set; }

        public NoteCategory Category { get; set; }
    }
}