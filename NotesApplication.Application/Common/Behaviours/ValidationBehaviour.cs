using FluentValidation;
using MediatR;
using NotesApplication.Application.Common.Responses;

namespace NotesApplication.Application.Common.Behaviours
{
    public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
        where TResponse : Response, new()
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }


        public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var context = new ValidationContext<TRequest>(request);

            var failures = _validators
                .Select(v => v.Validate(context))
                .SelectMany(result => result.Errors)
                .Where(failure => failure != null)
                .ToList();

            if (failures.Count != 0)
            {
                var response = new TResponse()
                {
                    IsSuccess = false,
                };

                foreach (var failure in failures)
                {
                    response.Errors.Add(failure.ErrorMessage);
                }

                return Task.FromResult(response);
            }

            return next();
        }
    }
}
