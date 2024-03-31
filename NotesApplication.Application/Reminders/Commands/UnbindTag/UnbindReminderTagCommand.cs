using MediatR;
using NotesApplication.Application.Common.Responses;

namespace NotesApplication.Application.Reminders.Commands.UnbindTag
{
    public class UnbindReminderTagCommand : IRequest<Response>
    {
        public int ReminderId { get; set; }

        public required string TagName { get; set; }
    }
}
