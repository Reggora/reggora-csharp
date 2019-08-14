using System;
using System.Net;
using Reggora.Api.Exceptions;

namespace Reggora.Api
{
    public class Reggora
    {
        public const string BaseUrl = "https://sandbox.reggora.io/";

        public static Lender Lender(string username, string password, string integrationToken)
        {
            return new Lender(integrationToken).Authenticate(username, password);
        }

        public static Vendor Vendor(string email, string password, string integrationToken)
        {
            return new Vendor(integrationToken).Authenticate(email, password);
        }

        public static ReggoraException RaiseRequestErrorToException(HttpStatusCode code, Exception innerError)
        {
            switch (code)
            {
                case HttpStatusCode.BadRequest:
                    return new BadRequestException(innerError);
                case HttpStatusCode.Unauthorized:
                    return new AuthorizationException(innerError);
                case HttpStatusCode.Forbidden:
                    return new InvalidParameterException(innerError);
                case HttpStatusCode.NotFound:
                    return new NotFoundException(innerError);
                case HttpStatusCode.InternalServerError:
                    return new InternalServerErrorException(innerError);
            }

            return new ReggoraException("Error executing request.", innerError);
        }
    }
}