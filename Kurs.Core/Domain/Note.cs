using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kurs.Core.Domain
{
    public class Note : BaseLookup
    {
        public DateTime CreatedOn { get; set; }

        public DateTime ModifiedOn { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }

        public User User { get; set; }

        [ForeignKey(nameof(Category))]
        public Guid? CategoryId { get; set; }

        public NoteCategory Category { get; set; }
    }
}