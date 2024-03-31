using MediatR;
using NotesApplication.Application.Common.Responses;

namespace NotesApplication.Application.Notes.Commands.Update
{
    public class UpdateNoteCommand : IRequest<Response>
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public string? Text { get; set; }
    }
}
