using MediatR;
using NotesApplication.Application.Common.Repository;
using NotesApplication.Application.Common.Responses;
using NotesApplication.Domain;

namespace NotesApplication.Application.Tags.Queries.GetAll
{
    public class GetAllTagsQueryHandler : IRequestHandler<GetAllTagsQuery, Response<IEnumerable<Tag>>>
    {
        private IRepository<Tag> _repository;

        public GetAllTagsQueryHandler(IRepository<Tag> repository)
        {
            _repository = repository;
        }

        public async Task<Response<IEnumerable<Tag>>> Handle(GetAllTagsQuery request, CancellationToken cancellationToken)
        {
            var tags = await _repository.GetAllAsync();

            return new Response<IEnumerable<Tag>>
            {
                IsSuccess = true,
                Value = tags
            };
        }
    }
}
