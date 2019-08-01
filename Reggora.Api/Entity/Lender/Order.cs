using System;
using Reggora.Api.Requests.Lender.Orders;

namespace Reggora.Api.Entity.Lender
{
    public class Order : Entity
    {
        public enum AllocationMode
        {
            Automatic,
            Manual
        }

        public enum PriorityType
        {
            Normal,
            Rush
        }

        public readonly EntityField<int> Number;
        public readonly EntityField<string> Status;
        public readonly EntityField<PriorityType> Priority;
        public readonly EntityField<DateTime> Due;
        public readonly EntityField<DateTime> InspectedAt;
        public readonly EntityField<DateTime> Created;
        public readonly EntityField<AllocationMode> Allocation;
        public readonly EntityField<bool> Inspected;
        public readonly EntityRelationship<Loan> Loan;

        public Order()
        {
            BuildField(ref Number, nameof(Number));
            BuildField(ref Status, nameof(Status));
            BuildField(ref Priority, nameof(Priority));
            BuildField(ref Due, nameof(Due));
            BuildField(ref InspectedAt, nameof(InspectedAt));
            BuildField(ref Created, nameof(Created));
            BuildField(ref Allocation, nameof(Allocation));
            BuildField(ref Inspected, nameof(Inspected));
            BuildRelationship(ref Loan);
        }

        public Order FromGetRequest(GetOrderRequest.Response.Order response)
        {
            Id.Value = response.Id;
            Status.Value = response.Status;
            Priority.Value = PriorityFromString(response.Priority);
            Due.Value = DateTime.Parse(response.DueDate);
            InspectedAt.Value = DateTime.Parse(response.InspectedDate);
            Created.Value = DateTime.Parse(response.Created);
            Allocation.Value = AllocationFromString(response.Allocation);
            Inspected.Value = response.InspectionComplete;
            Loan.Entity.FromGetRequest(response.LoanFile);

            return this;
        }
        
        public static string AllocationToString(AllocationMode allocation)
        {
            switch (allocation)
            {
                case AllocationMode.Automatic:
                    return "automatically";
                case AllocationMode.Manual:
                    return "manually";
            }

            return "";
        }
        
        public static AllocationMode AllocationFromString(string allocation)
        {
            switch (allocation.ToLower())
            {
                case "automatically":
                    return AllocationMode.Automatic;
                case "manually":
                    return AllocationMode.Manual;
            }

            throw new InvalidCastException($"Cannot cast string '{allocation}' to '{typeof(AllocationMode)}'!");
        }

        public static string PriorityToString(PriorityType priority)
        {
            switch (priority)
            {
                case PriorityType.Normal:
                    return "normal";
                case PriorityType.Rush:
                    return "rush";
            }

            return "";
        }

        public static PriorityType PriorityFromString(string priority)
        {
            switch (priority.ToLower())
            {
                case "normal":
                    return PriorityType.Normal;
                case "rush":
                    return PriorityType.Rush;
            }

            throw new InvalidCastException($"Cannot cast string '{priority}' to '{typeof(PriorityType)}'!");
        }
    }
}