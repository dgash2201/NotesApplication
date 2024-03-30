using FluentValidation;

namespace NotesApplication.Application.Tags.Commands.Delete
{
    public class DeleteTagCommandValidator : AbstractValidator<DeleteTagCommand>
    {
        public DeleteTagCommandValidator()
        {
            RuleFor(command => command.Id).NotEmpty();
        }
    }
}
