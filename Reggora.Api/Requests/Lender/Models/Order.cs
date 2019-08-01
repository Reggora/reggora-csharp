namespace Reggora.Api.Requests.Lender.Models
{
    public class Order
    {
        public string Id;
        public int Status;
        public Priority PriorityType;
        public string DueDate;
        public int InspectionDate;
        public AcceptedVendor AcceptedVendor;
        public string Created;
        public Allocation AllocationMode;
        public string[] RequestedVendors = {};
        public bool InspectionComplete;
        public Product[] Products = {};
        public LoanFile LoanFile;
        
        public enum Allocation
        {
            Automatic,
            Manual
        }
        
        public enum Priority
        {
            Normal,
            Rush
        }
        
        public static string AllocationToString(Allocation allocation)
        {
            switch (allocation)
            {
                case Allocation.Automatic:
                    return "automatically";
                case Allocation.Manual:
                    return "manually";
            }

            return "";
        }

        public static string PriorityToString(Priority priority)
        {
            switch (priority)
            {
                case Priority.Normal:
                    return "normal";
                case Priority.Rush:
                    return "rush";
            }

            return "";
        }
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