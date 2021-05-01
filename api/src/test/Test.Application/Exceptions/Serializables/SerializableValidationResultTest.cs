using Application.Exceptions.Serializables;
using System.ComponentModel.DataAnnotations;
using Xunit;

namespace Test.Application.Exceptions.Serializables
{
    public class SerializableValidationResultTest
    {
        private readonly ValidationResult Error1 = new ValidationResult("error 1");

        [Fact]
        public void Should_create_empty_one()
        {
            SerializableValidationResult serializableValidation = new SerializableValidationResult();

            Assert.Null(serializableValidation.ErrorMessage);
        }

        [Fact]
        public void Should_create_keep_validation_result()
        {
            SerializableValidationResult serializableValidation = new SerializableValidationResult(Error1);

            Assert.Equal(Error1.ErrorMessage, serializableValidation.ErrorMessage);
        }
    }
}
