namespace Reggora.Api.Requests.Lender.Models
{
    public class Order
    {
        public string Id;
        public int Status;
        public int Priority;
        public int DueDate;
        public int InspectionDate;
        public AcceptedVendor AcceptedVendor;
        public string Created;
        public string AllocationMode;
        public string[] RequestedVendors = {};
        public bool InspectionComplete;
        public Product[] Products = {};
        public LoanFile LoanFile;
    }

    public class AcceptedVendor
    {
        public string Id;
        public string ProductName;
        public float Amount;
    }

    public class LoanFile
    {
        public string Id;
        public string LoanNumber;
        public string SubjectPropertyAddress;
        public string SubjectPropertyCity;
        public string SubjectPropertyState;
        public int SubjectPropertyZip;
    }

}