namespace NotesApplication.Domain
{
    public class Tag : IEntity
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public IList<Reminder> Reminders { get; set; } = new List<Reminder>();

        public IList<Note> Notes { get; set; } = new List<Note>();
    }
}
