using MediatR;
using NotesApplication.Application.Common.Response;

namespace NotesApplication.Application.Reminders.Commands.Update
{
    public class UpdateReminderCommand : IRequest<Response>
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public string? Text { get; set; }
        public TimeOnly Time { get; set; }
    }
}
