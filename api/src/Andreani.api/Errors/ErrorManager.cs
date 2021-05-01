using E_Commers.Errors.ErrorResponses;
using System;
using System.Collections.Generic;

namespace E_Commers.Errors
{
    public class ErrorManager
    {
        private readonly Dictionary<Type, ErrorResponse> _mapper;

        public ErrorManager()
        {
            _mapper = new Dictionary<Type, ErrorResponse>();
        }

        public ErrorManager MapErrorToException<TException, TError>()
            where TException : Exception
            where TError : ErrorResponse, new()
        {
            _mapper.Add(typeof(TException), new TError());
            return this;
        }

        public IErrorResponse GetResponse(Exception ex)
        {
            return GetError(ex).SetTimeStamp(DateTime.Now).FillFromException(ex);
        }

        private ErrorResponse GetError(Exception ex)
        {
            return _mapper.GetValueOrDefault(ex.GetType()) ?? new GenericErrorResponse();
        }
    }
}
