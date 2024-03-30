namespace NotesApplication.Application.Common.Settings
{
    public class ApplicationSettings
    {
        public int MaxTagNameLength { get; init; } = 25;

        public int MaxReminderTitleLength { get; init; } = 40;

        public int MaxNoteTitleLength { get; init; } = 40;
    }
}
