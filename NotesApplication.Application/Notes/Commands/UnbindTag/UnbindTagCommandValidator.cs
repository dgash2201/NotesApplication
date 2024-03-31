using FluentValidation;

namespace NotesApplication.Application.Notes.Commands.UnbindTag
{
    public class UnbindTagCommandValidator : AbstractValidator<UnbindNoteTagCommand>
    {
        public UnbindTagCommandValidator()
        {
            RuleFor(command => command.NoteId).NotEmpty();
            RuleFor(command => command.TagName).NotEmpty();
        }
    }
}
