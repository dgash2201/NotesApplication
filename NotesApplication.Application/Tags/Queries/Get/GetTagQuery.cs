using MediatR;
using NotesApplication.Application.Common.Responses;
using NotesApplication.Domain;

namespace NotesApplication.Application.Tags.Queries.Get
{
    public class GetTagQuery : IRequest<Response<Tag>>
    {
        public int Id { get; set; }
    }
}
