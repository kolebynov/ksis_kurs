using Kurs.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace Kurs.Core.Data
{
    public class NotesContext : DbContext
    {
        public DbSet<Note> Notes { get; set; }
        public DbSet<NoteComment> NoteComments { get; set; }
        public DbSet<NoteFile> NoteFiles { get; set; }
        public DbSet<User> Users { get; set; }

        public NotesContext(DbContextOptions<NotesContext> options) : base(options)
        { }
    }
}