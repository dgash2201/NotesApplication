using MediatR;
using NotesApplication.Application.Common.Response;

namespace NotesApplication.Application.Notes.Commands.Update
{
    public class UpdateNoteCommand : IRequest<Response>
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public string? Text { get; set; }
    }
}
