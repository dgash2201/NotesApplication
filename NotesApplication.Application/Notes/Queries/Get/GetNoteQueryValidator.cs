using FluentValidation;
using NotesApplication.Application.Notes.Queries.Get;

namespace NotesApplication.Application.Remainder.Commands.Get
{
    public class GetNoteQueryValidator : AbstractValidator<GetNoteQuery>
    {
        public GetNoteQueryValidator()
        {
            RuleFor(query => query.Id).NotEmpty();
        }
    }
}
