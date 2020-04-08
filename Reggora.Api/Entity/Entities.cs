//
// WARNING: T4 GENERATED CODE - DO NOT EDIT
//

using Reggora.Api.Requests.Lender.Evaults;
using Reggora.Api.Requests.Lender.Models;
using Reggora.Api.Requests.Lender.Orders;
using Reggora.Api.Requests.Vendor.Conversation;
using Reggora.Api.Requests.Vendor.Order;
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
        public List<Consumer> Consumers { get => _consumers.Value; set => _consumers.Value = value; }

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
        private readonly EntityField<List<Consumer>> _consumers;

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
            BuildField(ref _consumers, "consumers");
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
        public GetOrderRequest.Response.Order.Loan LoanFile { get => _loanFile.Value; set => _loanFile.Value = value; }
        public PriorityType? Priority { get => _priority.Value; set => _priority.Value = value; }
        public List<string> ProductIds { get => _productIds.Value; set => _productIds.Value = value; }
        public List<GetOrderRequest.Response.Order.Product> Products { get => _products.Value; set => _products.Value = value; }
        public DateTime? Due { get => _due.Value; set => _due.Value = value; }
        public DateTime? InspectedAt { get => _inspectedAt.Value; set => _inspectedAt.Value = value; }
        public DateTime? Created { get => _created.Value; set => _created.Value = value; }
        public Vendr AcceptedVendor { get => _acceptedVendor.Value; set => _acceptedVendor.Value = value; }
        public string Evault { get => _evault.Value; set => _evault.Value = value; }
        public List<CreateOrderRequest.Request.AdditionalFee> AdditionalFees { get => _additionalFees.Value; set => _additionalFees.Value = value; }
        public List<Consumer> Consumers { get => _consumers.Value; set => _consumers.Value = value; }

        public bool Inspected { get => _inspected.Value; set => _inspected.Value = value; }

        private readonly EntityField<string> _id;
        private readonly EntityField<string> _status;
        private readonly EntityField<AllocationMode> _allocation;
        private readonly EntityField<string> _loan;
        private readonly EntityField<GetOrderRequest.Response.Order.Loan> _loanFile;
        private readonly EntityField<PriorityType?> _priority;
        private readonly EntityField<List<string>> _productIds;
        private readonly EntityField<List<GetOrderRequest.Response.Order.Product>> _products;
        private readonly EntityField<DateTime?> _due;
        private readonly EntityField<DateTime?> _inspectedAt;
        private readonly EntityField<DateTime?> _created;
        private readonly EntityField<bool> _inspected;
        private readonly EntityField<Vendr> _acceptedVendor;
        private readonly EntityField<string> _evault;
        private readonly EntityField<List<CreateOrderRequest.Request.AdditionalFee>> _additionalFees;
        private readonly EntityField<List<Consumer>> _consumers;
        public Order()
        {
            BuildField(ref _id, "id");
            BuildField(ref _status, "status");
            BuildField(ref _allocation, "string", "allocation_type");
            BuildField(ref _loan, "loan");
            BuildField(ref _loanFile, "loan_file");
            BuildField(ref _priority, "string", "priority");
            BuildField(ref _productIds, "product_ids");
            BuildField(ref _products, "products");
            BuildField(ref _due, "string", "due_date");
            BuildField(ref _inspectedAt, "string", "inspection_date");
            BuildField(ref _created, "string", "created");
            BuildField(ref _inspected, "inspection_complete");
            BuildField(ref _acceptedVendor, "accepted_vendor");
            BuildField(ref _evault, "evault");
            BuildField(ref _additionalFees, "additional_fees");
            BuildField(ref _consumers, "consumers");
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
    public class Submission : Entity
    {
       
        public string Version { get => _version.Value; set => _version.Value = value; }
        public string PdfReport { get => _pdfReport.Value; set => _pdfReport.Value = value; }
        public string XmlReport { get => _xmlReport.Value; set => _xmlReport.Value = value; }
        public string Invoice { get => _invoice.Value; set => _invoice.Value = value; }

        private readonly EntityField<string> _version;
        private readonly EntityField<string> _pdfReport;
        private readonly EntityField<string> _xmlReport;
        private readonly EntityField<string> _invoice;

        public Submission()
        {
            BuildField(ref _version, "version");
            BuildField(ref _pdfReport, "pdf_report");
            BuildField(ref _xmlReport, "xml_eport");
            BuildField(ref _invoice, "invoice");
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

    public class Vendr : Entity
    {
        public string Id { get => _id.Value; set => _id.Value = value; }
        public string FirmName { get => _firmName.Value; set => _firmName.Value = value; }
        public string Email { get => _email.Value; set => _email.Value = value; }
        public string Phone { get => _phone.Value; set => _phone.Value = value; }
        public string FirstName { get => _firstName.Value; set => _firstName.Value = value; }
        public string LastName { get => _lastName.Value; set => _lastName.Value = value; }
        public string Name { get => _name.Value; set => _name.Value = value; }
        public bool AcceptingJobs { get => _acceptingJobs.Value; set => _acceptingJobs.Value = value; }

        private readonly EntityField<string> _id;
        private readonly EntityField<string> _firmName;
        private readonly EntityField<string> _email;
        private readonly EntityField<string> _phone;
        private readonly EntityField<string> _firstName;
        private readonly EntityField<string> _lastName;
        private readonly EntityField<string> _name;
        private readonly EntityField<bool> _acceptingJobs;

        public Vendr()
        {

            BuildField(ref _id, "id");
            BuildField(ref _firmName, "firm_name");
            BuildField(ref _email, "email");
            BuildField(ref _phone, "phone");
            BuildField(ref _firstName,  "firstname");
            BuildField(ref _lastName, "lastname");
            BuildField(ref _name, "name");
            BuildField(ref _acceptingJobs, "accepting_jobs");
        }
    }

    public class PaymentApp : Entity
    {

        public enum PaymentType
        {
            Manual,
            Stripe,
        }


        public enum UserType
        {
            Manual,
            Consumer,
        }

        public enum LinkType
        {
            Payment,
            Scheduling,
            Both
        }

        public string ConsumerEmail { get => _consumerEmail.Value; set => _consumerEmail.Value = value; }
        public string OrderId { get => _orderId.Value; set => _orderId.Value = value; }
        public UserType UsrType { get => _userType.Value; set => _userType.Value = value; }
        public PaymentType PaymenType { get => _paymenType.Value; set => _paymenType.Value = value; }
        public float Amount { get => _amount.Value; set => _amount.Value = value; }
        public string FirstName { get => _firstName.Value; set => _firstName.Value = value; }
        public string LastName { get => _lastName.Value; set => _lastName.Value = value; }
        public bool Paid { get => _paid.Value; set => _paid.Value = value; }

        private readonly EntityField<string> _consumerEmail;
        private readonly EntityField<string> _orderId;
        private readonly EntityField<UserType> _userType;
        private readonly EntityField<PaymentType> _paymenType;
        private readonly EntityField<float> _amount;
        private readonly EntityField<string> _firstName;
        private readonly EntityField<string> _lastName;
        private readonly EntityField<bool> _paid;

        public PaymentApp()
        {

            BuildField(ref _consumerEmail, "consumer_email");
            BuildField(ref _orderId, "order_id");
            BuildField(ref _userType, "user_type");
            BuildField(ref _paymenType, "payment_type");
            BuildField(ref _amount, "amount");
            BuildField(ref _firstName, "firstname");
            BuildField(ref _lastName, "lastname");
            BuildField(ref _paid, "paid");
        }

        public static string PaymentTypeToString(PaymentType? value)
        {
            switch (value)
            {
                case PaymentType.Manual:
                    return "manual";
                case PaymentType.Stripe:
                    return "stripe";
            }

            throw new InvalidCastException($"Cannot cast '{typeof(PaymentType)}' to string!");
        }


        public static string UserTypeToString(UserType? value)
        {
            switch (value)
            {
                case UserType.Manual:
                    return "manual";
                case UserType.Consumer:
                    return "consumer";
            }

            throw new InvalidCastException($"Cannot cast '{typeof(UserType)}' to string!");
        }


        public static string LinkTypeToString(LinkType? value)
        {
            switch (value)
            {
                case LinkType.Payment:
                    return "payment";
                case LinkType.Scheduling:
                    return "scheduling";
                case LinkType.Both:
                    return "payment,scheduling";
            }

            throw new InvalidCastException($"Cannot cast '{typeof(LinkType)}' to string!");
        }
    }

    public class Evault : Entity
    {
        public string Id { get => _id.Value; set => _id.Value = value; }
        public List<GetEvaultRequest.Response.Evlt.Document> Documents { get => _documents.Value; set => _documents.Value = value; }

        private readonly EntityField<string> _id;
        private readonly EntityField<List<GetEvaultRequest.Response.Evlt.Document>> _documents;

        public Evault()
        {
            BuildField(ref _id, "id");
            BuildField(ref _documents, "documents");
        }
    }

    public class VendorOrder : Entity
    {
        
        public string Id { get => _id.Value; set => _id.Value = value; }
        public string Status { get => _status.Value; set => _status.Value = value; }
        public string PropertyStreet { get => _propertyStreet.Value; set => _propertyStreet.Value = value; }
        public string PropertyCity { get => _propertyCity.Value; set => _propertyCity.Value = value; }
        public string PropertyState { get => _propertyState.Value; set => _propertyState.Value = value; }
        public string PropertyZip { get => _propertyZip.Value; set => _propertyZip.Value = value; }
        public string Priority { get => _priority.Value; set => _priority.Value = value; }
        public string RequestExpiration { get => _requestExpiration.Value; set => _requestExpiration.Value = value; }
        public string DueDate { get => _dueDate.Value; set => _dueDate.Value = value; }
        public GetVendorOrderRequest.Response.Order.Lendr lender { get => _lender.Value; set => _lender.Value = value; }
        public GetVendorOrderRequest.Response.Order.Loan LoanFile { get => _loanFile.Value; set => _loanFile.Value = value; }
        public List<GetVendorOrderRequest.Response.Order.Consumer> Consumers { get => _consumers.Value; set => _consumers.Value = value; }
        public List<GetVendorOrderRequest.Response.Order.Schdl> Schedule { get => _schedule.Value; set => _schedule.Value = value; }
        public string Evault { get => _evault.Value; set => _evault.Value = value; }
        public string Conversation { get => _conversation.Value; set => _conversation.Value = value; }
        public List<GetVendorOrderRequest.Response.Order.Product> Products { get => _products.Value; set => _products.Value = value; }
        public List<GetVendorOrderRequest.Response.Order.Submission> Submissions { get => _submissions.Value; set => _submissions.Value = value; }
        public List<GetVendorOrderRequest.Response.Order.Revision> Revisions { get => _revisions.Value; set => _revisions.Value = value; }

        private readonly EntityField<string> _id;
        private readonly EntityField<string> _status;
        private readonly EntityField<string> _propertyStreet;
        private readonly EntityField<string> _propertyCity;
        private readonly EntityField<string> _propertyState;
        private readonly EntityField<string> _propertyZip;
        private readonly EntityField<string> _priority;
        private readonly EntityField<string> _requestExpiration;
        private readonly EntityField<string> _dueDate;

        private readonly EntityField<GetVendorOrderRequest.Response.Order.Lendr> _lender;
        private readonly EntityField<GetVendorOrderRequest.Response.Order.Loan> _loanFile;
        private readonly EntityField<List<GetVendorOrderRequest.Response.Order.Consumer>> _consumers;
        private readonly EntityField<List<GetVendorOrderRequest.Response.Order.Schdl>> _schedule;
        private readonly EntityField<List<GetVendorOrderRequest.Response.Order.Product>> _products;
        private readonly EntityField<List<GetVendorOrderRequest.Response.Order.Submission>> _submissions;
        private readonly EntityField<List<GetVendorOrderRequest.Response.Order.Revision>> _revisions;

        private readonly EntityField<string> _evault;
        private readonly EntityField<string> _conversation;

        public VendorOrder()
        {
            BuildField(ref _id, "id");
            BuildField(ref _status, "status");
            BuildField(ref _propertyStreet, "property_street");
            BuildField(ref _propertyCity, "property_city");
            BuildField(ref _propertyState, "property_state");
            BuildField(ref _propertyZip, "property_zip");
            BuildField(ref _priority, "priority");
            BuildField(ref _requestExpiration, "request_expiration");
            BuildField(ref _dueDate, "due_date");
            BuildField(ref _lender, "lender");
            BuildField(ref _loanFile, "loan_file");
            BuildField(ref _consumers, "consumers");
            BuildField(ref _schedule, "schedule");
            BuildField(ref _products, "products");
            BuildField(ref _submissions, "submissions");
            BuildField(ref _revisions, "revisions");
            BuildField(ref _evault, "evault");
            BuildField(ref _conversation, "conversation");
        }
    }

    public class Conversation : Entity
    {
        public string Id { get => _id.Value; set => _id.Value = value; }
        public List<GetConversationRequest.Response.Conversation.User> VendorUsers { get => _vendorUsers.Value; set => _vendorUsers.Value = value; }
        public List<GetConversationRequest.Response.Conversation.User> LenderUsers { get => _lenderUsers.Value; set => _lenderUsers.Value = value; }
        public List<GetConversationRequest.Response.Conversation.Msg> Messages { get => _messages.Value; set => _messages.Value = value; }

        private readonly EntityField<string> _id;
        private readonly EntityField<List<GetConversationRequest.Response.Conversation.User>> _vendorUsers;
        private readonly EntityField<List<GetConversationRequest.Response.Conversation.User>> _lenderUsers;
        private readonly EntityField<List<GetConversationRequest.Response.Conversation.Msg>> _messages;

        public Conversation()
        {
            BuildField(ref _id, "id");
            BuildField(ref _vendorUsers, "vendor_users");
            BuildField(ref _lenderUsers, "lender_users");
            BuildField(ref _messages, "messages");
        }

    }

    public class VendorEvault : Entity
    {
        public string Id { get => _id.Value; set => _id.Value = value; }
        public List<GetEvaultRequest.Response.Evlt.Document> Documents { get => _documents.Value; set => _documents.Value = value; }

        private readonly EntityField<string> _id;
        private readonly EntityField<List<GetEvaultRequest.Response.Evlt.Document>> _documents;

        public VendorEvault()
        {
            BuildField(ref _id, "id");
            BuildField(ref _documents, "documents");
        }
    }
}
