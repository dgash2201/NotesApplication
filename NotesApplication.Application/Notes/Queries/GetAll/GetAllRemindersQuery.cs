using MediatR;
using NotesApplication.Application.Common.Response;
using NotesApplication.Domain;

namespace NotesApplication.Application.Notes.Queries.GetAll
{
    public class GetAllNotesQuery : IRequest<Response<IEnumerable<Note>>>
    {
    }
}
