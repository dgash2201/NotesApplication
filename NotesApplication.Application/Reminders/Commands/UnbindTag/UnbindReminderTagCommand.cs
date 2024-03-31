using MediatR;
using NotesApplication.Application.Common.Responses;
using NotesApplication.Domain;

namespace NotesApplication.Application.Reminders.Commands.UnbindTag
{
    public class UnbindReminderTagCommand : IRequest<Response<Reminder>>
    {
        public int ReminderId { get; set; }

        public required string TagName { get; set; }
    }
}
