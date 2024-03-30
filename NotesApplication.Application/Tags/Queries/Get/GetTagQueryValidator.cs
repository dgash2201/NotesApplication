using FluentValidation;

namespace NotesApplication.Application.Tags.Queries.Get
{
    public class GetTagQueryValidator : AbstractValidator<GetTagQuery>
    {
        public GetTagQueryValidator()
        {
            RuleFor(query => query.Id).NotEmpty();
        }
    }
}
