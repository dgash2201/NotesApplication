using MediatR;
using NotesApplication.Application.Common.Responses;
using NotesApplication.Domain;

namespace NotesApplication.Application.Notes.Queries.GetAll
{
    public class GetAllNotesQuery : IRequest<Response<IEnumerable<Note>>>
    {
    }
}
