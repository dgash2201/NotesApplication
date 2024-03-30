using MediatR;
using NotesApplication.Application.Common.Response;
using NotesApplication.Domain;

namespace NotesApplication.Application.Notes.Commands.Create
{
    public class CreateNoteCommand : IRequest<Response<Note>>
    {
        public required string Title { get; set; }
        public string? Text { get; set; }
    }
}
