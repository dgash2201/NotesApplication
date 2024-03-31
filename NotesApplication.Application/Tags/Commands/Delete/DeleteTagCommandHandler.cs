using MediatR;
using NotesApplication.Application.Common.Repository;
using NotesApplication.Application.Common.Responses;
using NotesApplication.Domain;

namespace NotesApplication.Application.Tags.Commands.Delete
{
    public class DeleteTagCommandHandler : IRequestHandler<DeleteTagCommand, Response>
    {
        private readonly IRepository<Tag> _repository;

        public DeleteTagCommandHandler(IRepository<Tag> repository)
        {
            _repository = repository;
        }

        public async Task<Response> Handle(DeleteTagCommand request, CancellationToken cancellationToken)
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

            _repository.Delete(tag);
            await _repository.SaveChangesAsync();

            return new Response
            {
                IsSuccess = true
            };
        }
    }
}
