using MediatR;
using NotesApplication.Application.Common.Repository;
using NotesApplication.Application.Common.Response;
using NotesApplication.Domain;

namespace NotesApplication.Application.Reminders.Commands.UnbindTag
{
    public class UnbindTagCommandHandler : IRequestHandler<UnbindTagCommand, Response>
    {
        private readonly IRepository<Reminder> _repository;

        public UnbindTagCommandHandler(IRepository<Reminder> repository)
        {
            _repository = repository;
        }

        public Task<Response> Handle(UnbindTagCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
