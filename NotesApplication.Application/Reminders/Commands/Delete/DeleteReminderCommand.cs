using MediatR;
using NotesApplication.Application.Common.Responses;

namespace NotesApplication.Application.Reminders.Commands.Delete
{
    public class DeleteReminderCommand : IRequest<Response>
    {
        public int Id { get; set; }
    }
}
