using Application.Exceptions;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using Xunit;

namespace Test.Application.Exceptions
{
    public class ModelValidationExceptionTest
    {
        private const string Message = "Validation error";
        private readonly ValidationResult Error1 = new ValidationResult("error 1");
        private readonly ValidationResult Error2 = new ValidationResult("error 2");
        private readonly List<ValidationResult> ValidationResults = new List<ValidationResult>();

        public ModelValidationExceptionTest()
        {
            ValidationResults.Add(Error1);
            ValidationResults.Add(Error2);
        }


        [Fact]
        public void Should_create_empty_exception()
        {
            ModelValidationException ex = new ModelValidationException();

            Assert.Equal(Message, ex.Message);
        }


        [Fact]
        public void Should_serializate_correctly()
        {
            ModelValidationException ex = new ModelValidationException(ValidationResults);

            // Save the full ToString() value, including the exception message and stack trace.
            string exceptionToString = ex.ToString();

            string serializedData = JsonSerializer.Serialize(ex);
            ex = JsonSerializer.Deserialize<ModelValidationException>(serializedData);

            // Make sure custom properties are preserved after serialization
            Assert.Equal(Message, ex.Message);
            Assert.Equal(2, ex.ValidationErrors.Count);
            Assert.Equal(Error1.ErrorMessage, ex.ValidationErrors[0].ErrorMessage);
            Assert.Equal(Error2.ErrorMessage, ex.ValidationErrors[1].ErrorMessage);

            // Double-check that the exception message and stack trace (owned by the base Exception) are preserved
            Assert.Equal(exceptionToString, ex.ToString());
        }
    }
}
