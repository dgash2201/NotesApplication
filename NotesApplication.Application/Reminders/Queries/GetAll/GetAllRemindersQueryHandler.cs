using MediatR;
using NotesApplication.Application.Common.Repository;
using NotesApplication.Application.Common.Response;
using NotesApplication.Domain;

namespace NotesApplication.Application.Reminders.Queries.GetAll
{
    public class GetAllRemindersQueryHandler 
        : IRequestHandler<GetAllRemindersQuery, Response<IEnumerable<Reminder>>>
    {
        private IRepository<Reminder> _repository;

        public GetAllRemindersQueryHandler(IRepository<Reminder> repository)
        {
            _repository = repository;
        }

        public async Task<Response<IEnumerable<Reminder>>> Handle(GetAllRemindersQuery request, CancellationToken cancellationToken)
        {
            var reminders = await _repository.GetAllAsync();

            return new Response<IEnumerable<Reminder>>
            {
                IsSuccess = true,
                Value = reminders
            };
        }
    }
}
