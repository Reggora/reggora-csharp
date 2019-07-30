using System.Collections.Generic;
using Newtonsoft.Json;
using Reggora.Api.Authentication;
using Reggora.Api.Requests.Common;
using Reggora.Api.Requests.Lender;
using Reggora.Api.Requests.Lender.Loans;
using Reggora.Api.Requests.Lender.Models;
using RestSharp;
using RestSharp.Serializers.Newtonsoft.Json;
using RestRequest = RestSharp.RestRequest;

namespace Reggora.Api
{
    public class Lender
    {
        private readonly string _integrationToken;
        private readonly IRestClient _client;

        public Lender(string integrationToken)
        {
            _integrationToken = integrationToken;
            _client = new RestClient(Reggora.BaseUrl);
        }

        public Lender Authenticate(string username, string password)
        {
            var response = Execute<AuthenticateRequest.Response>(new LenderAuthenticateRequest(new AuthorizationRequest
                {Username = username, Password = password}));

            _client.Authenticator = new ReggoraJwtAuthenticator(_integrationToken, response.Token);

            return this;
        }

        #region loan methods

        #region get loans methods

        public List<Loan> Loans()
        {
            return Execute<GetLoansRequest.Response>(new GetLoansRequest()).Data;
        }

        public List<Loan> Loans(uint offset)
        {
            return Execute<GetLoansRequest.Response>(new GetLoansRequest{Offset = offset}).Data;
        }

        public List<Loan> Loans(uint offset, uint limit)
        {
            return Execute<GetLoansRequest.Response>(new GetLoansRequest{Offset = offset, Limit = limit}).Data;
        }

        public List<Loan> Loans(GetLoansRequest.Ordering order)
        {
            return Execute<GetLoansRequest.Response>(new GetLoansRequest{Order = order}).Data;
        }

        public List<Loan> Loans(LoanOfficer officer)
        {
            return Execute<GetLoansRequest.Response>(new GetLoansRequest{LoanOfficer = officer.Id}).Data;
        }

        public List<Loan> Loans(string loanOfficerId)
        {
            return Execute<GetLoansRequest.Response>(new GetLoansRequest{LoanOfficer = loanOfficerId}).Data;
        }

        public List<Loan> Loans(uint offset, uint limit, GetLoansRequest.Ordering order)
        {
            return Execute<GetLoansRequest.Response>(new GetLoansRequest{Offset = offset, Limit = limit, Order = order}).Data;
        }

        public List<Loan> Loans(uint offset, uint limit, GetLoansRequest.Ordering order, LoanOfficer officer)
        {
            return Execute<GetLoansRequest.Response>(new GetLoansRequest{Offset = offset, Limit = limit, Order = order, LoanOfficer = officer.Id}).Data;
        }

        public List<Loan> Loans(uint offset, uint limit, GetLoansRequest.Ordering order, string loanOfficerId)
        {
            return Execute<GetLoansRequest.Response>(new GetLoansRequest{Offset = offset, Limit = limit, Order = order, LoanOfficer = loanOfficerId}).Data;
        }

        #endregion

        #region get loan methods

        public Loan Loan(Loan loan)
        {
            return Execute<GetLoanRequest.Response>(new GetLoanRequest(loan.Id)).Data;
        }
        
        public Loan Loan(string id)
        {
            return Execute<GetLoanRequest.Response>(new GetLoanRequest(id)).Data;
        }

        #endregion

        #region delete loan methods

        public string DeleteLoan(Loan loan)
        {
            return Execute<DeleteLoanRequest.Response>(new DeleteLoanRequest(loan.Id)).Data;
        }
        
        public string DeleteLoan(string id)
        {
            return Execute<DeleteLoanRequest.Response>(new DeleteLoanRequest(id)).Data;
        }

        #endregion
        
        #region create loan methods

        public string CreateLoan(Loan loan)
        {
            return Execute<CreateLoanRequest.Response>(new CreateLoanRequest(loan)).Data;
        }

        #endregion
        
        #region update loan methods

        public string UpdateLoan(Loan loan)
        {
            return Execute<EditLoanRequest.Response>(new EditLoanRequest(loan)).Data;
        }

        #endregion

        #endregion

        public T Execute<T>(RestRequest request) where T : new()
        {
            request.JsonSerializer = new NewtonsoftJsonSerializer(new JsonSerializer{NullValueHandling = NullValueHandling.Ignore});
            
            var response = _client.Execute<T>(request);

            if (response.ErrorException != null)
            {
                throw Reggora.RaiseRequestErrorToException(response.StatusCode, response.ErrorException);
            }

            return response.Data;
        }
    }
}