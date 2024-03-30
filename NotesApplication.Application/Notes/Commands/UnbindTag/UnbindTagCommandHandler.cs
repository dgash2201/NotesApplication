using MediatR;
using NotesApplication.Application.Common.Repository;
using NotesApplication.Application.Common.Response;
using NotesApplication.Domain;

namespace NotesApplication.Application.Notes.Commands.UnbindTag
{
    public class UnbindTagCommandHandler : IRequestHandler<UnbindTagCommand, Response>
    {
        private readonly IRepository<Note> _repository;

        public UnbindTagCommandHandler(IRepository<Note> repository)
        {
            _repository = repository;
        }

        public Task<Response> Handle(UnbindTagCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
