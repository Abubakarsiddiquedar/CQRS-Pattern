using FluentValidation;
using Food.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food.Application.Behaviour
{
    public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validator;
        public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validator)
        {
            _validator = validator;
        }
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            //pre-processing logic here
            if (_validator.Any())
            {
                var validationContext = new ValidationContext<TRequest>(request);
                var result = await Task.WhenAll(_validator.Select(x => x.ValidateAsync(validationContext, cancellationToken)));
                var failers = result.SelectMany(r => r.Errors).Where(f => f != null).ToList();

                if (failers.Count > 0)
                {
                    throw new ValidtionErrorException(failers);
                }
            }

            var response = await next();
            return response;
            //Next
            //post-processing
            //ForExample
        }
    }
}
