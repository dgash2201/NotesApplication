using MediatR;
using NotesApplication.Application.Common.Repository;
using NotesApplication.Application.Common.Responses;
using NotesApplication.Domain;

namespace NotesApplication.Application.Tags.Queries.GetByName
{
    public class GetTagByNameQueryHandler : IRequestHandler<GetTagByNameQuery, Response<Tag>>
    {
        private readonly IRepository<Tag> _repository;

        public GetTagByNameQueryHandler(IRepository<Tag> repository)
        {
            _repository = repository;
        }

        public async Task<Response<Tag>> Handle(GetTagByNameQuery request, CancellationToken cancellationToken)
        {
            var contains = await _repository.ContainsAsync(x => x.Name == request.Name);

            if (!contains)
            {
                return new Response<Tag>()
                {
                    IsSuccess = false,
                    Errors = new List<string>() { "Такого тэга не существует\n" },
                };
            }

            var tag = await _repository.GetAsync(x => x.Name == request.Name);

            return new Response<Tag>
            {
                IsSuccess = true,
                Value = tag
            };
        }
    }
}
