using FluentValidation;
using NotesApplication.Application.Common.Settings;

namespace NotesApplication.Application.Reminders.Commands.Update
{
    public class UpdateReminderCommandValidator : AbstractValidator<UpdateReminderCommand>
    {
        public UpdateReminderCommandValidator()
        {
            RuleFor(command => command.Id)
                .NotEmpty();

            RuleFor(command => command.Title)
                .NotEmpty()
                .MaximumLength(Config.ApplicationSettings.MaxReminderTitleLength);
        }
    }
}
