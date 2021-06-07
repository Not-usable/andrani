using Microsoft.AspNetCore.Mvc;
using System;

namespace Andreani.Errors.ErrorResponses
{
    public interface IErrorResponse
    {
        ObjectResult GetResult();
    }
}
