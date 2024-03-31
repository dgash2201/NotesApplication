using MediatR;
using NotesApplication.Application.Common.Responses;
using NotesApplication.Domain;

namespace NotesApplication.Application.Tags.Queries.GetByName
{
    public class GetTagByNameQuery : IRequest<Response<Tag>>
    {
        public required string Name { get; set; }
    }
}
