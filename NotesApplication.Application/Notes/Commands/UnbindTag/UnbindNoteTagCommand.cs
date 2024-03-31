using MediatR;
using NotesApplication.Application.Common.Responses;

namespace NotesApplication.Application.Notes.Commands.UnbindTag
{
    public class UnbindNoteTagCommand : IRequest<Response>
    {
        public int NoteId { get; set; }

        public required string TagName { get; set; }
    }
}
