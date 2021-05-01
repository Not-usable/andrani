using Application.Exceptions;
using Application.Exceptions.Serializables;
using System;
using System.Collections.Generic;

namespace E_Commers.Errors.ErrorResponses
{
    public class ModelValidationErrorResponse : ErrorResponse
    {
        public List<SerializableValidationResult> ValidationErrors { get; set; }

        public ModelValidationErrorResponse() : base("Model validation error")
        {
        }

        public override ErrorResponse FillFromException(Exception ex)
        {
            ValidationErrors = ((ModelValidationException)ex).ValidationErrors;
            return this;
        }
    }
}
