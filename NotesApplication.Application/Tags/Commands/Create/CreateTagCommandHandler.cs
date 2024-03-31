using MediatR;
using NotesApplication.Application.Common.Repository;
using NotesApplication.Application.Common.Responses;
using NotesApplication.Domain;

namespace NotesApplication.Application.Tags.Commands.Create
{
    public class CreateTagCommandHandler : IRequestHandler<CreateTagCommand, Response<Tag>>
    {
        private readonly IRepository<Tag> _repository;

        public CreateTagCommandHandler(IRepository<Tag> repository)
        {
            _repository = repository;
        }

        public async Task<Response<Tag>> Handle(CreateTagCommand request, CancellationToken cancellationToken)
        {
            if (await _repository.ContainsAsync(t => t.Name == request.Name))
            {
                return new Response<Tag>
                {
                    IsSuccess = false,
                    Errors = new List<string>() { "Такой тег уже существует" }
                };
            }

            var tag = new Tag
            {
                Name = request.Name,
            };

            _repository.Add(tag);
            await _repository.SaveChangesAsync();

            return new Response<Tag>()
            {
                IsSuccess = true,
                Value = tag
            };
        }
    }
}
