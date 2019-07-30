using System;

namespace Reggora.Api.Exceptions
{
    public class BadRequestException : ReggoraException
    {
        public BadRequestException(Exception innerError) : base("Bad Request -- Your request is invalid.", innerError)
        {
        }

        public BadRequestException(string message, Exception innerError) : base(message, innerError)
        {
        }
    }
}