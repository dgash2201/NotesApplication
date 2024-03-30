namespace NotesApplication.Domain
{
    public class Reminder : IEntity
    {
        public int Id { get; set; }

        public required string Title { get; set; }

        public string? Text { get; set; }

        public TimeOnly Time { get; set; }

        public IList<Tag> Tags { get; set; } = new List<Tag>();
    }
}
