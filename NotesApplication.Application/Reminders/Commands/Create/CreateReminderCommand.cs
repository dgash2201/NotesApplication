using MediatR;
using NotesApplication.Application.Common.Responses;
using NotesApplication.Domain;

namespace NotesApplication.Application.Reminders.Commands.Create
{
    public class CreateReminderCommand : IRequest<Response<Reminder>>
    {
        public required string Title { get; set; }
        public string? Text { get; set; }
        public TimeOnly Time { get; set; }
    }
}
