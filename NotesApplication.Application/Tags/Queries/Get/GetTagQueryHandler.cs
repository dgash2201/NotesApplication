using MediatR;
using NotesApplication.Application.Common.Repository;
using NotesApplication.Application.Common.Response;
using NotesApplication.Domain;

namespace NotesApplication.Application.Tags.Queries.Get
{
    public class GetTagQueryHandler : IRequestHandler<GetTagQuery, Response<Tag>>
    {
        private readonly IRepository<Tag> _repository;

        public GetTagQueryHandler(IRepository<Tag> repository)
        {
            _repository = repository;
        }

        public async Task<Response<Tag>> Handle(GetTagQuery request, CancellationToken cancellationToken)
        {
            var tag = await _repository.GetAsync(request.Id);

            return new Response<Tag>
            {
                IsSuccess = true,
                Value = tag
            };
        }
    }
}
