using FluentValidation;
using NotesApplication.Application.Common.Settings;

namespace NotesApplication.Application.Notes.Commands.Create
{
    public class CreateNoteCommandValidator : AbstractValidator<CreateNoteCommand>
    {
        public CreateNoteCommandValidator()
        {
            RuleFor(command => command.Title)
                .NotEmpty()
                .MaximumLength(Config.ApplicationSettings.MaxNoteTitleLength);
        }
    }
}
