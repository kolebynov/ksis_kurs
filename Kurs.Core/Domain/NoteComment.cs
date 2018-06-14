using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kurs.Core.Domain
{
    [DisplayColumn(nameof(Text))]
    public class NoteComment : BaseEntity, IDateTrackable
    {
        [MaxLength(500)]
        public string Text { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime ModifiedOn { get; set; }

        [ForeignKey(nameof(Note))]
        public Guid NoteId { get; set; }

        public Note Note { get; set; }
    }
}