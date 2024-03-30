using FluentValidation;
using NotesApplication.Application.Common.Settings;

namespace NotesApplication.Application.Notes.Commands.Update
{
    public class UpdateNoteCommandValidator : AbstractValidator<UpdateNoteCommand>
    {
        public UpdateNoteCommandValidator()
        {
            RuleFor(command => command.Id)
                .NotEmpty();

            RuleFor(command => command.Title)
                .NotEmpty()
                .MaximumLength(Config.ApplicationSettings.MaxNoteTitleLength);
        }
    }
}
