using FluentValidation;
using NotesApplication.Application.Common.Settings;
using System.Data;

namespace NotesApplication.Application.Tags.Commands.Create
{
    public class CreateTagCommandValidator : AbstractValidator<CreateTagCommand>
    {
        public CreateTagCommandValidator()
        {
            RuleFor(command => command.Name)
                .NotEmpty()
                .MaximumLength(Config.ApplicationSettings.MaxTagNameLength);
        }
    }
}
