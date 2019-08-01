using System;
using Reggora.Api.Requests.Lender.Loans;

namespace Reggora.Api.Entity.Lender
{
    public class Loan : Entity
    {
        public readonly EntityField<int?> Number;
        public readonly EntityField<string> Type;
        public readonly EntityField<DateTime?> Due;
        public readonly EntityField<DateTime?> Created;
        public readonly EntityField<DateTime?> Updated;
        public readonly EntityField<Property> Property;
        public readonly EntityField<string> CaseNumber;

        public Loan()
        {
            BuildField(ref Number, nameof(Number));
            BuildField(ref Type, nameof(Type));
            BuildField(ref Due, nameof(Due));
            BuildField(ref Created, nameof(Created));
            BuildField(ref Updated, nameof(Updated));
            BuildField(ref Property, nameof(Property));
            BuildField(ref CaseNumber, nameof(CaseNumber));
        }

        public Loan FromGetRequest(GetLoanRequest.Response.Loan response)
        {
            Id.Value = response.Id;
            Number.Value = EntityField.IntFromString(response.LoanNumber);
            Type.Value = response.LoanType;
            Due.Value = DateTime.Parse(response.DueDate);
            Created.Value = EntityField.DateTimeFromString(response.Created ?? "");
            Updated.Value = EntityField.DateTimeFromString(response.Updated ?? "");
            Property.Value = new Property(this);
            Property.Value.Address.Value = response.SubjectPropertyAddress;
            Property.Value.City.Value = response.SubjectPropertyCity;
            Property.Value.State.Value = response.SubjectPropertyState;
            Property.Value.Zip.Value = response.SubjectPropertyZip;
            CaseNumber.Value = response.CaseNumber;
            
            return this;
        }
    }
}