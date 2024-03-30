using MediatR;
using NotesApplication.Application.Common.Response;
using NotesApplication.Domain;

namespace NotesApplication.Application.Reminders.Commands.BindTags
{
    public class BindTagsCommand : IRequest<Response<Reminder>>
    {
        public int ReminderId { get; init; }

        public IReadOnlyList<string> TagNames { get; init; } = new List<string>();
    }
}
