using MediatR;
using NotesApplication.Application.Common.Response;

namespace NotesApplication.Application.Notes.Commands.Delete
{
    public class DeleteNoteCommand : IRequest<Response>
    {
        public int Id { get; set; }
    }
}
