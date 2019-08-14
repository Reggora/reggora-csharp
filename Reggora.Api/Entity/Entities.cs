//
// WARNING: T4 GENERATED CODE - DO NOT EDIT
//

using System;

namespace Reggora.Api.Entity
{
    public class Loan : Entity
    {
        public string Id
        {
            get => _id.Value;
            set => _id.Value = value;
        }

        public int? Number
        {
            get => _number.Value;
            set => _number.Value = value;
        }

        public string Type
        {
            get => _type.Value;
            set => _type.Value = value;
        }

        public DateTime? Due
        {
            get => _due.Value;
            set => _due.Value = value;
        }

        public DateTime? Created
        {
            get => _created.Value;
            set => _created.Value = value;
        }

        public DateTime? Updated
        {
            get => _updated.Value;
            set => _updated.Value = value;
        }

        public string PropertyAddress
        {
            get => _propertyAddress.Value;
            set => _propertyAddress.Value = value;
        }

        public string PropertyCity
        {
            get => _propertyCity.Value;
            set => _propertyCity.Value = value;
        }

        public string PropertyState
        {
            get => _propertyState.Value;
            set => _propertyState.Value = value;
        }

        public string PropertyZip
        {
            get => _propertyZip.Value;
            set => _propertyZip.Value = value;
        }

        public string CaseNumber
        {
            get => _caseNumber.Value;
            set => _caseNumber.Value = value;
        }

        private readonly EntityField<string> _id;
        private readonly EntityField<int?> _number;
        private readonly EntityField<string> _type;
        private readonly EntityField<DateTime?> _due;
        private readonly EntityField<DateTime?> _created;
        private readonly EntityField<DateTime?> _updated;
        private readonly EntityField<string> _propertyAddress;
        private readonly EntityField<string> _propertyCity;
        private readonly EntityField<string> _propertyState;
        private readonly EntityField<string> _propertyZip;
        private readonly EntityField<string> _caseNumber;

        public Loan()
        {
            BuildField(ref _id, "id");
            BuildField(ref _number, "number");
            BuildField(ref _type, "type");
            BuildField(ref _due, "due_date");
            BuildField(ref _created, "created");
            BuildField(ref _updated, "updated");
            BuildField(ref _propertyAddress, "subject_property_address");
            BuildField(ref _propertyCity, "subject_property_city");
            BuildField(ref _propertyState, "subject_property_state");
            BuildField(ref _propertyZip, "subject_property_zip");
            BuildField(ref _caseNumber, "case_number");
        }
    }

    public class Order : Entity
    {
        public enum PriorityType
        {
            Automatic,
            Manual,
        }

        public enum AllocationMode
        {
            Normal,
            Rush,
        }

        public string Id
        {
            get => _id.Value;
            set => _id.Value = value;
        }

        public string Status
        {
            get => _status.Value;
            set => _status.Value = value;
        }

        public PriorityType? Priority
        {
            get => _priority.Value;
            set => _priority.Value = value;
        }

        public DateTime? Due
        {
            get => _due.Value;
            set => _due.Value = value;
        }

        public DateTime? InspectedAt
        {
            get => _inspectedAt.Value;
            set => _inspectedAt.Value = value;
        }

        public DateTime? Updated
        {
            get => _updated.Value;
            set => _updated.Value = value;
        }

        public AllocationMode Allocation
        {
            get => _allocation.Value;
            set => _allocation.Value = value;
        }

        public bool Inspected
        {
            get => _inspected.Value;
            set => _inspected.Value = value;
        }

        private readonly EntityField<string> _id;
        private readonly EntityField<string> _status;
        private readonly EntityField<PriorityType?> _priority;
        private readonly EntityField<DateTime?> _due;
        private readonly EntityField<DateTime?> _inspectedAt;
        private readonly EntityField<DateTime?> _updated;
        private readonly EntityField<AllocationMode> _allocation;
        private readonly EntityField<bool> _inspected;

        public Order()
        {
            BuildField(ref _id, "id");
            BuildField(ref _status, "status");
            BuildField(ref _priority, "priority");
            BuildField(ref _due, "due_date");
            BuildField(ref _inspectedAt, "inspected_at");
            BuildField(ref _updated, "updated");
            BuildField(ref _allocation, "allocation_mode");
            BuildField(ref _inspected, "inspection_complete");
        }

        public static string PriorityTypeToString(PriorityType? value)
        {
            switch (value)
            {
                case PriorityType.Automatic:
                    return "automatically";
                case PriorityType.Manual:
                    return "manually";
            }

            throw new InvalidCastException($"Cannot cast '{typeof(PriorityType)}' to string!");
        }

        public static PriorityType PriorityTypeFromString(string value)
        {
            switch (value)
            {
                case "automatically":
                    return PriorityType.Automatic;
                case "manually":
                    return PriorityType.Manual;
            }

            throw new InvalidCastException($"Cannot cast string '{value}' to '{typeof(PriorityType)}'!");
        }

        public static string AllocationModeToString(AllocationMode? value)
        {
            switch (value)
            {
                case AllocationMode.Normal:
                    return "normal";
                case AllocationMode.Rush:
                    return "rush";
            }

            throw new InvalidCastException($"Cannot cast '{typeof(AllocationMode)}' to string!");
        }

        public static AllocationMode AllocationModeFromString(string value)
        {
            switch (value)
            {
                case "normal":
                    return AllocationMode.Normal;
                case "rush":
                    return AllocationMode.Rush;
            }

            throw new InvalidCastException($"Cannot cast string '{value}' to '{typeof(AllocationMode)}'!");
        }
    }
}