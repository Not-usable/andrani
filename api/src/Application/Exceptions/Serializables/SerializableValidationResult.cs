using System.ComponentModel.DataAnnotations;

namespace Application.Exceptions.Serializables
{
    public class SerializableValidationResult : ValidationResult
    {
        public SerializableValidationResult() : base((string)null) { }
        public SerializableValidationResult(ValidationResult result) : base(result) { }
    }
}
