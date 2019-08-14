using Reggora.Api.Entity;
using Reggora.Api.Requests.Lender.Loans;
using Reggora.Api.Util;

namespace Reggora.Api.Storage.Lender
{
    public class LoanStorage : Storage<Loan, Api.Lender>
    {
        public LoanStorage(Api.Lender api) : base(api)
        {
        }

        public override Loan Get(string id)
        {
            Known.TryGetValue(id, out var returned);

            if (returned == null)
            {
                var result = new GetLoanRequest(id).Execute(Api.Client);
                if (result.Status == 200)
                {
                    returned = new Loan();
                    returned.UpdateFromRequest(Utils.DictionaryOfJsonFields(result.Data.Loan));
                    Known.Add(returned.Id, returned);
                }
            }

            return returned;
        }
    }
}