using MediatR;
using NotesApplication.Application.Common.Repository;
using NotesApplication.Application.Common.Response;
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
