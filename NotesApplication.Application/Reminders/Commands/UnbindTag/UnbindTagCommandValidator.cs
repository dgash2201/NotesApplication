using FluentValidation;

namespace NotesApplication.Application.Reminders.Commands.UnbindTag
{
    public class UnbindTagCommandValidator : AbstractValidator<UnbindReminderTagCommand>
    {
        public UnbindTagCommandValidator()
        {
            RuleFor(command => command.ReminderId).NotEmpty();
            RuleFor(command => command.TagName).NotEmpty();
        }
    }
}
