using MediatR;
using NotesApplication.Application.Common.Responses;
using NotesApplication.Domain;

namespace NotesApplication.Application.Notes.Commands.BindTags
{
    public class BindNoteTagsCommand : IRequest<Response<Note>>
    {
        public int NoteId { get; init; }

        public IReadOnlyList<string> TagNames { get; init; } = new List<string>();
    }
}
