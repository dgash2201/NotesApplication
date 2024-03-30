using FluentValidation;
using NotesApplication.Application.Reminders.Queries.Get;

namespace NotesApplication.Application.Remainder.Commands.Get
{
    public class GetReminderQueryValidator : AbstractValidator<GetReminderQuery>
    {
        public GetReminderQueryValidator()
        {
            RuleFor(query => query.Id).NotEmpty();
        }
    }
}
