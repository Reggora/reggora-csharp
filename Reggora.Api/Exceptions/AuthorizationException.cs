using System;

namespace Reggora.Api.Exceptions
{
    public class AuthorizationException : ReggoraException
    {
        public AuthorizationException(Exception innerError) : base("Unauthorized -- Your Bearer Token is invalid.",
            innerError)
        {
        }

        public AuthorizationException(string message, Exception innerError) : base(message, innerError)
        {
        }
    }
}