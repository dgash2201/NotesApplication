using FluentValidation;

namespace NotesApplication.Application.Notes.Commands.BindTags
{
    public class BindTagsCommandValidator : AbstractValidator<BindNoteTagsCommand>
    {
        public BindTagsCommandValidator()
        {
            RuleFor(command => command.NoteId).NotEmpty();
        }
    }
}
