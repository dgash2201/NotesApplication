using FluentValidation;

namespace NotesApplication.Application.Reminders.Commands.BindTags
{
    public class BindTagsCommandValidator : AbstractValidator<BindTagsCommand>
    {
        public BindTagsCommandValidator()
        {
            RuleFor(command => command.ReminderId).NotEmpty();
        }
    }
}
