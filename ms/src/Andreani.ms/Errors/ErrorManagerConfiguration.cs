using Application.Exceptions;
using Andreani.Errors.ErrorResponses;
using System.Diagnostics.CodeAnalysis;

namespace Andreani.Errors
{
    [ExcludeFromCodeCoverage]
    public class ErrorManagerConfiguration
    {
        public ErrorManager Configure(ErrorManager em)
        {
            return em.MapErrorToException<ModelValidationException, ModelValidationErrorResponse>();
        }
    }
}
