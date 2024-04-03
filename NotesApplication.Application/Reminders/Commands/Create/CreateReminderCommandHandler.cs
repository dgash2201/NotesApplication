using MediatR;
using NotesApplication.Application.Common.Repository;
using NotesApplication.Application.Common.Responses;
using NotesApplication.Domain;

namespace NotesApplication.Application.Reminders.Commands.Create
{
    public class CreateReminderCommandHandler : IRequestHandler<CreateReminderCommand, Response<Reminder>>
    {
        private IRepository<Reminder> _repository;

        public CreateReminderCommandHandler(IRepository<Reminder> repository)
        {
            _repository = repository;
        }

        public async Task<Response<Reminder>> Handle(CreateReminderCommand request, CancellationToken cancellationToken)
        {
            var contains = await _repository.ContainsAsync(x => x.Title == request.Title);

            if (!contains)
            {
                return new Response<Reminder>()
                {
                    IsSuccess = false,
                    Errors = new List<string>() { "Напоминание с таким заголовком уже существует\n" },
                };
            }

            var reminder = new Reminder()
            {
                Title = request.Title,
                Text = request.Text,
                Time = request.Time,
            };

            _repository.Add(reminder);
            await _repository.SaveChangesAsync();

            return new Response<Reminder>
            {
                IsSuccess = true,
                Value = reminder,
            };
        }
    }
}
