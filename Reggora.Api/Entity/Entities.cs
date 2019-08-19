//
// WARNING: T4 GENERATED CODE - DO NOT EDIT
//

using System;
using System.Collections.Generic;

namespace Reggora.Api.Entity
{
    public class Loan : Entity
    {

        public string Id { get => _id.Value; set => _id.Value = value; }
        public string Number { get => _number.Value; set => _number.Value = value; }
        public string Type { get => _type.Value; set => _type.Value = value; }
        public DateTime? Due { get => _due.Value; set => _due.Value = value; }
        public DateTime? Created { get => _created.Value; set => _created.Value = value; }
        public DateTime? Updated { get => _updated.Value; set => _updated.Value = value; }
        public string PropertyAddress { get => _propertyAddress.Value; set => _propertyAddress.Value = value; }
        public string PropertyCity { get => _propertyCity.Value; set => _propertyCity.Value = value; }
        public string PropertyState { get => _propertyState.Value; set => _propertyState.Value = value; }
        public string PropertyZip { get => _propertyZip.Value; set => _propertyZip.Value = value; }
        public string CaseNumber { get => _caseNumber.Value; set => _caseNumber.Value = value; }
        public string AppraisalType { get => _appraisalType.Value; set => _appraisalType.Value = value; }

        private readonly EntityField<string> _id;
        private readonly EntityField<string> _number;
        private readonly EntityField<string> _type;
        private readonly EntityField<DateTime?> _due;
        private readonly EntityField<DateTime?> _created;
        private readonly EntityField<DateTime?> _updated;
        private readonly EntityField<string> _propertyAddress;
        private readonly EntityField<string> _propertyCity;
        private readonly EntityField<string> _propertyState;
        private readonly EntityField<string> _propertyZip;
        private readonly EntityField<string> _caseNumber;
        private readonly EntityField<string> _appraisalType;

        public Loan()
        {
            BuildField(ref _id, "id");
            BuildField(ref _number, "loan_number");
            BuildField(ref _type, "loan_type");
            BuildField(ref _due, "string", "due_date");
            BuildField(ref _created, "string", "created");
            BuildField(ref _updated, "string", "updated");
            BuildField(ref _propertyAddress, "subject_property_address");
            BuildField(ref _propertyCity, "subject_property_city");
            BuildField(ref _propertyState, "subject_property_state");
            BuildField(ref _propertyZip, "subject_property_zip");
            BuildField(ref _caseNumber, "case_number");
            BuildField(ref _appraisalType, "appraisal_type");
        }

    }
    public class Order : Entity
    {
        public enum PriorityType
        {
            Normal,
            Rush,
        }
        public enum AllocationMode
        {
            Automatic,
            Manual,
        }

        public string Id { get => _id.Value; set => _id.Value = value; }
        public string Status { get => _status.Value; set => _status.Value = value; }
        public AllocationMode Allocation { get => _allocation.Value; set => _allocation.Value = value; }
        public string Loan { get => _loan.Value; set => _loan.Value = value; }
        public PriorityType? Priority { get => _priority.Value; set => _priority.Value = value; }
        public string[] Products { get => _products.Value; set => _products.Value = value; }
        public DateTime? Due { get => _due.Value; set => _due.Value = value; }
        public DateTime? InspectedAt { get => _inspectedAt.Value; set => _inspectedAt.Value = value; }
        public DateTime? Updated { get => _updated.Value; set => _updated.Value = value; }

        public bool Inspected { get => _inspected.Value; set => _inspected.Value = value; }

        private readonly EntityField<string> _id;
        private readonly EntityField<string> _status;
        private readonly EntityField<AllocationMode> _allocation;
        private readonly EntityField<string> _loan;
        private readonly EntityField<PriorityType?> _priority;
        private readonly EntityField<string[]> _products;
        private readonly EntityField<DateTime?> _due;
        private readonly EntityField<DateTime?> _inspectedAt;
        private readonly EntityField<DateTime?> _updated;
        private readonly EntityField<bool> _inspected;

        public Order()
        {
            BuildField(ref _id, "id");
            BuildField(ref _status, "status");
            BuildField(ref _allocation, "string", "allocation_type");
            BuildField(ref _loan, "loan");
            BuildField(ref _priority, "string", "priority");
            BuildField(ref _products, "string[]", "products");
            BuildField(ref _due, "string", "due_date");
            BuildField(ref _inspectedAt, "string", "inspected_at");
            BuildField(ref _updated, "string", "updated");
            BuildField(ref _inspected, "inspection_complete");
        }

        public static string PriorityTypeToString(PriorityType? value)
        {
            switch (value)
            {
                case PriorityType.Normal:
                    return "Normal";
                case PriorityType.Rush:
                    return "Rush";
            }

            throw new InvalidCastException($"Cannot cast '{typeof(PriorityType)}' to string!");
        }

        public static PriorityType PriorityTypeFromString(string value)
        {
            switch (value.ToLowerInvariant())
            {
                case "normal":
                    return PriorityType.Normal;
                case "rush":
                    return PriorityType.Rush;
            }

            throw new InvalidCastException($"Cannot cast string '{value}' to '{typeof(PriorityType)}'!");
        }
        public static string AllocationModeToString(AllocationMode? value)
        {
            switch (value)
            {
                case AllocationMode.Automatic:
                    return "automatically";
                case AllocationMode.Manual:
                    return "manually";
            }

            throw new InvalidCastException($"Cannot cast '{typeof(AllocationMode)}' to string!");
        }

        public static AllocationMode AllocationModeFromString(string value)
        {
            switch (value.ToLowerInvariant())
            {
                case "automatically":
                    return AllocationMode.Automatic;
                case "manually":
                    return AllocationMode.Manual;
            }

            throw new InvalidCastException($"Cannot cast string '{value}' to '{typeof(AllocationMode)}'!");
        }

    }
    public class Product : Entity
    {
        public enum Inspection
        {
            Interior,
            Exterior
        }

        public string Id { get => _id.Value; set => _id.Value = value; }
        public string ProductName { get => _productName.Value; set => _productName.Value = value; }
        public float Amount { get => _amount.Value; set => _amount.Value = value; }
        public Inspection InspectionType { get => _inspectionType.Value; set => _inspectionType.Value = value; }
        public string RequestForms { get => _requestForms.Value; set => _requestForms.Value = value; }

        private readonly EntityField<string> _id;
        private readonly EntityField<string> _productName;
        private readonly EntityField<float> _amount;
        private readonly EntityField<Inspection> _inspectionType;
        private readonly EntityField<string> _requestForms;

        public Product()
        {
            BuildField(ref _id, "id");
            BuildField(ref _productName, "product_name");
            BuildField(ref _amount, "amount");
            BuildField(ref _inspectionType, "string", "inspection_type");
            BuildField(ref _requestForms, "requested_forms");
        }

        public static string InspectionToString(Inspection inspection)
        {
            switch (inspection)
            {
                case Inspection.Interior:
                    return "interior";
                case Inspection.Exterior:
                    return "exterior";
            }

            return "";
        }

        public static Inspection InspectionFromString(string value)
        {
            switch (value.ToLowerInvariant())
            {
                case "interior":
                    return Inspection.Interior;
                case "exterior":
                    return Inspection.Exterior;
            }

            throw new InvalidCastException($"Cannot cast string '{value}' to '{typeof(Inspection)}'!");
        }
    }
    public class User : Entity
    {
        public string Id { get => _id.Value; set => _id.Value = value; }
        public string Email { get => _email.Value; set => _email.Value = value; }
        public string PhoneNumber { get => _phoneNumber.Value; set => _phoneNumber.Value = value; }
        public string FirstName { get => _firstName.Value; set => _firstName.Value = value; }
        public string LastName { get => _lastName.Value; set => _lastName.Value = value; }
        public string NmlsId { get => _nmlsId.Value; set => _nmlsId.Value = value; }
        public DateTime? Created { get => _created.Value; set => _created.Value = value; }
        public string Role { get => _role.Value; set => _role.Value = value; }
        public string Branch { get => _branchId.Value; set => _branchId.Value = value; }

        private readonly EntityField<string> _id;
        private readonly EntityField<string> _email;
        private readonly EntityField<string> _phoneNumber;
        private readonly EntityField<string> _firstName;
        private readonly EntityField<string> _lastName;
        private readonly EntityField<string> _nmlsId;
        private readonly EntityField<DateTime?> _created;
        private readonly EntityField<string> _role;
        private readonly EntityField<string> _branchId;

        public User()
        {
            BuildField(ref _id, "id");
            BuildField(ref _email, "email");
            BuildField(ref _phoneNumber, "phone_number");
            BuildField(ref _firstName, "string", "firstname");
            BuildField(ref _lastName, "string", "lastname");
            BuildField(ref _nmlsId, "string", "nmls_id");
            BuildField(ref _created, "string", "created");
            BuildField(ref _role, "string", "role");
            BuildField(ref _branchId, "string", "brnach_id");
    }
}
}
