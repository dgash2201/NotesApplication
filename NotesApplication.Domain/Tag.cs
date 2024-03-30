namespace NotesApplication.Domain
{
    public class Tag : IEntity
    {
        public int Id { get; set; }

        public required string Name { get; set; }
    }
}
