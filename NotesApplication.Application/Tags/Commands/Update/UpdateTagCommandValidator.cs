using FluentValidation;
using NotesApplication.Application.Common.Settings;

namespace NotesApplication.Application.Tags.Commands.Update
{
    public class UpdateTagCommandValidator : AbstractValidator<UpdateTagCommand>
    {
        public UpdateTagCommandValidator()
        {
            RuleFor(command => command.Id).NotEmpty();
            RuleFor(command => command.Name)
                .NotEmpty()
                .MaximumLength(Config.ApplicationSettings.MaxTagNameLength);

            RuleFor(command => command.Name)
                .Matches(@"^\w+$")
                .WithMessage("Имя тэга должно содержать только буквы и цифры без пробелов");
        }
    }
}
