using System;
using System.Runtime.Serialization;

namespace Reggora.Api.Exceptions
{
    public class ReggoraException : ApplicationException
    {
        public ReggoraException()
        {
        }

        protected ReggoraException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public ReggoraException(string message) : base(message)
        {
        }

        public ReggoraException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}