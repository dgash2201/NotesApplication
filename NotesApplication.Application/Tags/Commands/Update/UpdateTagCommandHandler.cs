using MediatR;
using NotesApplication.Application.Common.Repository;
using NotesApplication.Application.Common.Responses;
using NotesApplication.Domain;

namespace NotesApplication.Application.Tags.Commands.Update
{
    public class UpdateTagCommandHandler : IRequestHandler<UpdateTagCommand, Response<Tag>>
    {
        private readonly IRepository<Tag> _repository;

        public UpdateTagCommandHandler(IRepository<Tag> repository)
        {
            _repository = repository;
        }

        public async Task<Response<Tag>> Handle(UpdateTagCommand request, CancellationToken cancellationToken)
        {
            var contains = await _repository.ContainsAsync(x => x.Id == request.Id);

            if (!contains)
            {
                return new Response<Tag>()
                {
                    IsSuccess = false,
                    Errors = new List<string>() { "Такого тэга не существует\n" },
                };
            }

            var tag = await _repository.GetAsync(request.Id);
            tag.Name = request.Name;
            await _repository.SaveChangesAsync();

            return new Response<Tag>()
            {
                IsSuccess = true,
                Value = tag
            };
        }
    }
}
