using Reggora.Api.Entity;
using Reggora.Api.Requests.Lender.Loans;
using Reggora.Api.Util;
using System.Collections.Generic;

namespace Reggora.Api.Storage.Lender
{
    public class LoanStorage : Storage<Loan, Api.Lender>
    {
        public LoanStorage(Api.Lender api) : base(api)
        {
        }

        public List<Loan> All(uint offset = 0, uint limit = 0, string ordering = "-created", string loanOfficer = null)
        {
            var result = new GetLoansRequest(offset, limit, ordering, loanOfficer).Execute(Api.Client);
            var fetchedLoans = result.Data.Loans;
            List<Loan> loans = new List<Loan>();

            if (result.Status == 200)
            {
                for (int i = 0; i < fetchedLoans.Count; i++)
                {
                    Loan tempLoan = new Loan();
                    tempLoan.UpdateFromRequest(Utils.DictionaryOfJsonFields(fetchedLoans[i]));
                    loans.Add(tempLoan);
                }
            }
            return loans;
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

        public override void Save(Loan loan)
        {
            var result = new EditLoanRequest(loan).Execute(Api.Client);
            if (result.Status == 200)
            {
                loan.Clean();
            }
        }

        public string Create(Loan loan)
        {
            string response = "";
            var result = new CreateLoanRequest(loan).Execute(Api.Client);
            if (result.Status == 200)
            {
                response = result.Data;
                loan.Clean();

            }

            return response;
        }

        public string Edit(Loan loan)
        {
            string response = "";
            var result = new EditLoanRequest(loan).Execute(Api.Client);
            if (result.Status == 200)
            {
                response = result.Data;
                loan.Clean();
            }
            return response;
        }

        public string Delete(string id)
        {
            string response = null;
            var result = new DeleteLoanRequest(id).Execute(Api.Client);
            if (result.Status == 200)
            {
                response = result.Data;
            }
            return response;
        }

        /// <summary>
        /// Get Loan Schema (Extended)
        /// </summary>
        /// <returns>Return a list of all Loan fields</returns>
        public List<string> GetSchema()
        {
            List<string> response = new List<string>();

            var result = new GetLoanSchemaRequest().Execute(Api.Client);
            if (result.Status == 200)
            {
                response = Utils.ListOfJsonString(result.Data);
            }

            return response;
        }

        /// <summary>
        ///Create a Loan with custom fields that are setup in the Settings tab within the lender platform. (Extended)
        /// </summary>
        /// <param name="loanParams">Loan fields name and value as a dictionary</param>
        /// <returns>ID of the created Loan</returns>
        public string Create(Dictionary<string, object> loanParams)
        {
            string response = "";
            var result = new CreateExtendedLoanRequest(loanParams).Execute(Api.Client);
            if (result.Status == 200)
            {
                response = result.Data;
            }

            return response;
        }

        /// <summary>
        /// Edit a Loan with custom fields that are setup in the Settings tab within the lender platform. (Extended)
        /// </summary>
        /// <param name="loanID">Loan ID to be edited</param>
        /// <param name="loanParams">Loan fields name and value as a dictionary</param>
        /// <returns>ID of the edited Loan</returns>
        public string Edit(string loanID, Dictionary<string, object> loanParams)
        {
            string response = "";
            var result = new EditExtendedLoanRequest(loanID, loanParams).Execute(Api.Client);
            if (result.Status == 200)
            {
                response = result.Data;
            }
            return response;
        }


    }
}