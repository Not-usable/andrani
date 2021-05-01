using Application.Exceptions;
using E_Commers.Errors.ErrorResponses;
using System.Diagnostics.CodeAnalysis;

namespace E_Commers.Errors
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
