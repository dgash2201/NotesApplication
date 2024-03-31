using MediatR;
using NotesApplication.Application.Common.Responses;
using NotesApplication.Domain;

namespace NotesApplication.Application.Tags.Queries.GetAll
{
    public class GetAllTagsQuery : IRequest<Response<IEnumerable<Tag>>>
    { }
}
