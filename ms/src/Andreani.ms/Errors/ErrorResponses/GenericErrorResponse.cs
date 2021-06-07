using Application.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Andreani.Errors.ErrorResponses
{
    public class GenericErrorResponse : ErrorResponse
    {
        public GenericErrorResponse() : base("Internal server error") { }
    }
}
