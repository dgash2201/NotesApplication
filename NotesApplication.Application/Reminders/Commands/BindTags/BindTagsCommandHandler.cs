using MediatR;
using NotesApplication.Application.Common.Repository;
using NotesApplication.Application.Common.Responses;
using NotesApplication.Application.Tags.Commands.Create;
using NotesApplication.Domain;

namespace NotesApplication.Application.Reminders.Commands.BindTags
{
    public class BindTagsCommandHandler : IRequestHandler<BindReminderTagsCommand, Response<Reminder>>
    {
        private readonly IRepository<Reminder> _repository;
        private readonly IMediator _mediator;

        public BindTagsCommandHandler(IRepository<Reminder> repository, IMediator mediator)
        {
            _repository = repository;
            _mediator = mediator;
        }

        public async Task<Response<Reminder>> Handle(BindReminderTagsCommand request, CancellationToken cancellationToken)
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

            var reminder = await _repository.GetAsync(request.ReminderId);

            foreach (var tagName in request.TagNames)
            {
                var createTagCommand = new CreateTagCommand()
                {
                    Name = tagName,
                };

                var tagResponse = await _mediator.Send(createTagCommand);

                if (tagResponse.IsSuccess)
                {
                    reminder.Tags.Add(tagResponse.Value);
                }
            }

            await _repository.SaveChangesAsync();

            return new Response<Reminder>()
            {
                IsSuccess = true,
                Value = reminder
            };
        }
    }
}
