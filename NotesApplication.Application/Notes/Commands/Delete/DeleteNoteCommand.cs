using MediatR;
using NotesApplication.Application.Common.Responses;

namespace NotesApplication.Application.Notes.Commands.Delete
{
    public class DeleteNoteCommand : IRequest<Response>
    {
        public int Id { get; set; }
    }
}
