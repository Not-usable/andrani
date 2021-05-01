using Application.Exceptions;
using E_Commers.Errors.ErrorResponses;
using E_Commers.Errors;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Xunit;

namespace Test.Adapters.Errors
{
    public class ErrorManagerTest
    {
        [Fact]
        public void Should_convert_to_generic_error()
        {
            ErrorManager em = new ErrorManager();

            var res = em.GetResponse(new Exception());

            Assert.IsType<GenericErrorResponse>(res);
        }

        [Fact]
        public void Should_convert_to_specific_error()
        {
            ErrorManager em = new ErrorManager();
            em.MapErrorToException<ModelValidationException, ModelValidationErrorResponse>();

            var res = em.GetResponse(new ModelValidationException(new List<ValidationResult>()));

            Assert.IsType<ModelValidationErrorResponse>(res);
        }
    }
}
