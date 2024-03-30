using MediatR;
using NotesApplication.Application.Common.Response;
using NotesApplication.Domain;

namespace NotesApplication.Application.Notes.Queries.Get
{
    public class GetNoteQuery : IRequest<Response<Note>>
    {
        public int Id { get; set; }
    }
}
