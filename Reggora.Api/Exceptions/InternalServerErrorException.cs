using System;

namespace Reggora.Api.Exceptions
{
    public class InternalServerErrorException : ReggoraException
    {
        public InternalServerErrorException(Exception innerError) : base(
            "Internal Server Error -- We had a problem with our server. Try again later.", innerError)
        {
        }

        public InternalServerErrorException(string message, Exception innerError) : base(message, innerError)
        {
        }
    }
}