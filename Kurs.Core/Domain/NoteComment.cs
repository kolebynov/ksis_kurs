using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Kurs.Core.Domain
{
    [DisplayColumn(nameof(Text))]
    public class NoteComment : BaseEntity
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