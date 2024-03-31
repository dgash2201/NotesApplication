using MediatR;
using NotesApplication.Application.Common.Repository;
using NotesApplication.Application.Common.Responses;
using NotesApplication.Domain;

namespace NotesApplication.Application.Reminders.Commands.Update
{
    public class UpdateReminderCommandHandler : IRequestHandler<UpdateReminderCommand, Response>
    {
        private IRepository<Reminder> _repository;

        public UpdateReminderCommandHandler(IRepository<Reminder> repository)
        {
            _repository = repository;
        }

        public async Task<Response> Handle(UpdateReminderCommand request, CancellationToken cancellationToken)
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

            var reminder = await _repository.GetAsync(x => x.Id == request.Id);

            reminder.Title = request.Title;
            reminder.Time = request.Time;
            reminder.Text = request.Text;

            return new Response()
            {
                IsSuccess = true,
            };
        }
    }
}
