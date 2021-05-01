using Application.Exceptions;
using E_Commers.Errors.ErrorResponses;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Xunit;

namespace Test.Adapters.Errors.ErrorResponses
{
    public class ModelValidationErrorResponseTest
    {
        [Fact]
        public void Should_keep_validation_errors()
        {
            List<ValidationResult> validationResults = new List<ValidationResult>();
            ModelValidationException ex = new ModelValidationException(validationResults);
            ModelValidationErrorResponse er = new ModelValidationErrorResponse();

            er.FillFromException(ex);

            Assert.Equal(validationResults, er.ValidationErrors);
        }
    }
}
