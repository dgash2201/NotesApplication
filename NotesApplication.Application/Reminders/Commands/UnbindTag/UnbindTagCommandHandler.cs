using MediatR;
using NotesApplication.Application.Common.Repository;
using NotesApplication.Application.Common.Responses;
using NotesApplication.Application.Tags.Commands.Create;
using NotesApplication.Application.Tags.Queries.GetByName;
using NotesApplication.Domain;

namespace NotesApplication.Application.Reminders.Commands.UnbindTag
{
    public class UnbindTagCommandHandler : IRequestHandler<UnbindReminderTagCommand, Response<Reminder>>
    {
        private readonly IRepository<Reminder> _repository;
        private readonly IMediator _mediator;

        public UnbindTagCommandHandler(IRepository<Reminder> repository, IMediator mediator)
        {
            _repository = repository;
            _mediator = mediator;
        }

        public async Task<Response<Reminder>> Handle(UnbindReminderTagCommand request, CancellationToken cancellationToken)
        {
            var contains = await _repository.ContainsAsync(x => x.Id == request.ReminderId);

            if (!contains)
            {
                return new Response<Reminder>()
                {
                    IsSuccess = false,
                    Errors = new List<string>() { "Такого напоминания не существует\n" },
                };
            }

            var tagName = request.TagName;
            var tagQuery = new GetTagByNameQuery() { Name = tagName };
            var tagResponse = await _mediator.Send(tagQuery);

            if (!tagResponse.IsSuccess)
            {
                return new Response<Reminder>()
                {
                    IsSuccess = false,
                    Errors = new List<string>() { "Такого тэга не сущетвует\n"},
                };
            }

            var reminder = await _repository.GetAsync(x => x.Id == request.ReminderId);
            reminder.Tags.Remove(tagResponse.Value);

            await _repository.SaveChangesAsync();

            return new Response<Reminder>()
            {
                IsSuccess = true,
                Value = reminder
            };
        }
    }
}
