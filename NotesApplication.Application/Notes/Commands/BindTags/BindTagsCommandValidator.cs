using FluentValidation;

namespace NotesApplication.Application.Notes.Commands.BindTags
{
    public class BindTagsCommandValidator : AbstractValidator<BindTagsCommand>
    {
        public BindTagsCommandValidator()
        {
            RuleFor(command => command.NoteId).NotEmpty();
        }
    }
}
