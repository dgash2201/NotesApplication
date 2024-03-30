using FluentValidation;

namespace NotesApplication.Application.Notes.Commands.Delete
{
    public class DeleteNoteCommandValidator : AbstractValidator<DeleteNoteCommand>
    {
        public DeleteNoteCommandValidator()
        {
            RuleFor(command => command.Id).NotEmpty();
        }
    }
}
