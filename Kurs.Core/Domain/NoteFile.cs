using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Kurs.Core.Domain
{
    [DisplayColumn(nameof(FileName))]
    public class NoteFile : BaseEntity
    {
        public string ContentType { get; set; }

        public string FileName { get; set; }

        public long Length { get; set; }

        [ForeignKey(nameof(Note))]
        public Guid NoteId { get; set; }

        public Note Note { get; set; }

        [IgnoreDataMember]
        public byte[] Data { get; set; }
    }
}