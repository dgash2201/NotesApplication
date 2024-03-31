using FluentValidation;

namespace NotesApplication.Application.Tags.Queries.GetByName
{
    public class GetTagByNameQueryValidator : AbstractValidator<GetTagByNameQuery>
    {
        public GetTagByNameQueryValidator()
        {
            RuleFor(query => query.Name).NotEmpty();
        }
    }
}
