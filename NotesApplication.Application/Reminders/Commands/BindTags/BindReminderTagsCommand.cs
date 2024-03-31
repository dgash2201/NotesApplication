using MediatR;
using NotesApplication.Application.Common.Responses;
using NotesApplication.Domain;

namespace NotesApplication.Application.Reminders.Commands.BindTags
{
    public class BindReminderTagsCommand : IRequest<Response<Reminder>>
    {
        public int ReminderId { get; init; }

        public IReadOnlyList<string> TagNames { get; init; } = new List<string>();
    }
}
