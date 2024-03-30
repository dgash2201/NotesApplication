using FluentValidation;

namespace NotesApplication.Application.Reminders.Commands.Delete
{
    public class DeleteReminderCommandValidator : AbstractValidator<DeleteReminderCommand>
    {
        public DeleteReminderCommandValidator()
        {
            RuleFor(command => command.Id).NotEmpty();
        }
    }
}
