using Application.Exceptions.Serializables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.Serialization;

namespace Application.Exceptions
{
    [Serializable]
    public class ModelValidationException : Exception
    {
        public List<SerializableValidationResult> ValidationErrors { get; set; }

        public ModelValidationException(List<ValidationResult> validationResults) : base("Validation error")
        {
            ValidationErrors = validationResults.Select(x => new SerializableValidationResult(x)).ToList();
        }

        public ModelValidationException() : base("Validation error") { }

        [ExcludeFromCodeCoverage] //It is not possible to correct test it since Formaters have benn deprecated
        protected ModelValidationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            ValidationErrors = (List<SerializableValidationResult>)info.GetValue("ValidationErrors", typeof(List<SerializableValidationResult>));
        }

        [ExcludeFromCodeCoverage] //It is not possible to correct test it since Formaters have benn deprecated
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
            {
                throw new ArgumentNullException(nameof(info));
            }

            info.AddValue("ValidationErrors", ValidationErrors, typeof(List<SerializableValidationResult>));

            base.GetObjectData(info, context);
        }
    }
}
