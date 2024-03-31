using MediatR;
using NotesApplication.Application.Common.Repository;
using NotesApplication.Application.Common.Responses;
using NotesApplication.Domain;

namespace NotesApplication.Application.Reminders.Queries.Get
{
    public class GetReminderQueryHandler : IRequestHandler<GetReminderQuery, Response<Reminder>>
    {
        private IRepository<Reminder> _repository;

        public GetReminderQueryHandler(IRepository<Reminder> repository)
        {
            _repository = repository;
        }

        public async Task<Response<Reminder>> Handle(GetReminderQuery request, CancellationToken cancellationToken)
        {
            var contains = await _repository.ContainsAsync(x => x.Id == request.Id);

            if (!contains)
            {
                return new Response<Reminder>()
                {
                    IsSuccess = false,
                    Errors = new List<string>() { "Такого напоминания не существует\n" },
                };
            }

            var reminder = await _repository.GetAsync(x => x.Id == request.Id);

            return new Response<Reminder>()
            {
                IsSuccess = true,
                Value = reminder,
            };
        }
    }
}
