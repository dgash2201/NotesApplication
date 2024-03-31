using MediatR;
using NotesApplication.Application.Common.Repository;
using NotesApplication.Application.Common.Responses;
using NotesApplication.Domain;

namespace NotesApplication.Application.Reminders.Commands.UnbindTag
{
    public class UnbindTagCommandHandler : IRequestHandler<UnbindReminderTagCommand, Response>
    {
        private readonly IRepository<Reminder> _repository;

        public UnbindTagCommandHandler(IRepository<Reminder> repository)
        {
            _repository = repository;
        }

        public Task<Response> Handle(UnbindReminderTagCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
