using Application.Exceptions;
using Application.Exceptions.Serializables;
using MediatR;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Behaviors
{
    public class ValidatorBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var results = new List<ValidationResult>();
            var context = new ValidationContext(request, null, null);
            if (!Validator.TryValidateObject(request, context, results))
            {
                throw new ModelValidationException(results);
            }

            return await next();
        }
    }
}
