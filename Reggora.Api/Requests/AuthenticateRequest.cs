using System;
using RestSharp;

namespace Reggora.Api.Requests
{
    public abstract class AuthenticateRequest : RestRequest
    {
        protected AuthenticateRequest(string type, Object authInfo) : base(type + "/auth", Method.POST)
        {
            AddJsonBody(authInfo);
        }
    }
}