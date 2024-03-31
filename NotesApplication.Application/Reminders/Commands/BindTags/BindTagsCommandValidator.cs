using FluentValidation;

namespace NotesApplication.Application.Reminders.Commands.BindTags
{
    public class BindTagsCommandValidator : AbstractValidator<BindReminderTagsCommand>
    {
        public BindTagsCommandValidator()
        {
            RuleFor(command => command.ReminderId).NotEmpty();
        }
    }
}
