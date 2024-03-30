using MediatR;
using NotesApplication.Application.Common.Repository;
using NotesApplication.Application.Common.Response;
using NotesApplication.Domain;

namespace NotesApplication.Application.Reminders.Commands.Delete
{
    public class DeleteReminderCommandHandler : IRequestHandler<DeleteReminderCommand, Response>
    {
        private IRepository<Reminder> _repository;

        public DeleteReminderCommandHandler(IRepository<Reminder> repository)
        {
            _repository = repository;
        }

        public async Task<Response> Handle(DeleteReminderCommand request, CancellationToken cancellationToken)
        {
            var contains = await _repository.ContainsAsync(x => x.Id == request.Id);

            if (!contains)
            {
                return new Response()
                {
                    IsSuccess = false,
                    Errors = new List<string>() { "Такого напоминания не существует\n" },
                };
            }

            var reminder = await _repository.GetAsync(request.Id);

            _repository.Delete(reminder);

            return new Response()
            {
                IsSuccess = true
            };
        }
    }
}
