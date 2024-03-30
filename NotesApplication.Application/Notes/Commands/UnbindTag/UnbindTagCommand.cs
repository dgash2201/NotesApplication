using MediatR;
using NotesApplication.Application.Common.Response;

namespace NotesApplication.Application.Notes.Commands.UnbindTag
{
    public class UnbindTagCommand : IRequest<Response>
    {
        public int NoteId { get; set; }

        public required string TagName { get; set; }
    }
}
