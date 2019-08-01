using Reggora.Api.Entity.Lender;
using Reggora.Api.Requests.Lender.Loans;

namespace Reggora.Api.Storage.Lender
{
    public class LoanStorage : Storage<Loan, Api.Lender>
    {
        public LoanStorage(Api.Lender lender) : base(lender)
        {
        }

        public Loan Get(string id)
        {
            Known.TryGetValue(id, out var returned);

            if (returned == null)
            {
                // TODO: Verify response
                var result = new GetLoanRequest(id).Execute(Api.Client).Data;
                returned = new Loan().FromGetRequest(result);
            }

            return returned;
        }
    }
}