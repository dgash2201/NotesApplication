using FluentValidation;
using NotesApplication.Application.Common.Settings;

namespace NotesApplication.Application.Reminders.Commands.Create
{
    public class CreateReminderCommandValidator : AbstractValidator<CreateReminderCommand>
    {
        public CreateReminderCommandValidator()
        {
            RuleFor(command => command.Title)
                .NotEmpty()
                .MaximumLength(Config.ApplicationSettings.MaxReminderTitleLength);
        }
    }
}
