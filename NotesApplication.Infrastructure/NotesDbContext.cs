using Microsoft.EntityFrameworkCore;
using NotesApplication.Domain;

namespace NotesApplication.Infrastructure
{
    public class NotesDbContext : DbContext
    {
        public DbSet<Tag> Tags { get; set; }

        public DbSet<Reminder> Reminders { get; set; }

        public DbSet<Note> Notes { get; set; }

        public NotesDbContext(DbContextOptions<NotesDbContext> options) : base(options) {}

    }
}
