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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Tag>()
                .HasIndex(x => x.Name)
                .IsUnique();

            modelBuilder.Entity<Reminder>()
                .HasIndex(x => x.Title)
                .IsUnique();
            
            modelBuilder.Entity<Reminder>()
                .HasMany(x => x.Tags)
                .WithMany(x => x.Reminders);

            modelBuilder.Entity<Note>()
                .HasIndex(x => x.Title)
                .IsUnique();

            modelBuilder.Entity<Note>()
                .HasMany(x => x.Tags)
                .WithMany(x => x.Notes);
        }

    }
}
