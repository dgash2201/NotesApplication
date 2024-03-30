using MediatR;
using NotesApplication.Application.Common.Response;

namespace NotesApplication.Application.Reminders.Commands.UnbindTag
{
    public class UnbindTagCommand : IRequest<Response>
    {
        public int ReminderId { get; set; }

        public required string TagName { get; set; }
    }
}
