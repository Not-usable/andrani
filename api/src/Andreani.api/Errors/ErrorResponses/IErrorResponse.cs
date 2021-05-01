using Microsoft.AspNetCore.Mvc;
using System;

namespace E_Commers.Errors.ErrorResponses
{
    public interface IErrorResponse
    {
        ObjectResult GetResult();
    }
}
