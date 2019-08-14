using System;

namespace Reggora.Api.Exceptions
{
    public class InvalidParameterException : ReggoraException
    {
        public InvalidParameterException(Exception innerError) : base(
            "Invalid Parameter -- Either the URL parameters or the request body parameters are invalid.", innerError)
        {
        }

        public InvalidParameterException(string message, Exception innerError) : base(message, innerError)
        {
        }
    }
}