using Application.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace E_Commers.Errors.ErrorResponses
{
    public class GenericErrorResponse : ErrorResponse
    {
        public GenericErrorResponse() : base("Internal server error") { }
    }
}
