# Reggora

## Welcome to `Reggora` api!
### `Reggora C# library` works for `Lender` and `Vendor` APIs supported by [Reggora](https://sandbox.reggora.io/).

## Dependencies
- NuGet (5.2.0)
- NuGet Packages
 Response: If downloaded successfully, `true`, otherwise, `false`
  - MimeMapping v1.0.1.14
  - Newtonsoft.Json v12.0.2
  - RestSharp v106.6.10
  - RestSharp.Newtonsoft.Json v1.5.1
  - Syroot.Windows.IO.KnownFolders v1.2.1
- Microsoft.NETCore.App (2.2.0)

## Building and importing Library 
 - You can get library by building `Reggora.Api`
 - Once the building is done, you can see the library `Reggora.Api.dll` in `Reggora.Api\bin\Release\netcoreapp2.2` directory.
 - You can import this library from adding `Reference`.

## Usage for Lender API

- Initializing Library
    
    ```c#
    private Lender lender = new Lender(integrationToken);
    lender.Authenticate(lenderUserName, lenderPassword); 
    ```
- Make a Request
    
    - Loans
    
        - Get all Loans
            [View detail](https://sandbox.reggora.io/#get-all-loans)
            ```
                uint Offset = 0;
                uint Limit = 0;
                string ordering = "-created";
                string loanOfficer = null;
          
                List<Loan> loans = lender.Loans.All(Offset, limit, ordering, loanOfficer);
            ```
			Response: List of `Loan`

        - Get a Loan
            [View detail](https://sandbox.reggora.io/#get-loan)
            ```
                Loan loan = lender.Loans.Get(string loanId);
            ```
        
        - Delete a Loan
            [View detail](https://sandbox.reggora.io/#delete-loan)
            ```
                string response = lender.Loans.Delete(string loanId);
            ```
            Response: "Loan deleted."

        - Create a Loan
            [View detail](https://sandbox.reggora.io/#create-a-loan)
            ```
                Loan loan = new Loan()
                            {
                                Number = "1",
                                Type = "FHA",
                                Due = DateTime.Now.AddYears(1),
                                PropertyAddress = "100 Mass Ave",
                                PropertyCity = "Boston",
                                PropertyState = "MA",
                                PropertyZip = "02192",
                                CaseNumber = "10029MA",
                                AppraisalType = "Refinance"
                            };
                string response = lender.Loans.Create(loan);
            ```
			Resposne: Id of created Loan

        - Edit a Loan
            [View detail](https://sandbox.reggora.io/#edit-a-loan)
            ```
                loan.Number = "newLoanNumber";
                string response = lender.Loans.Edit(loan);
            ```
			Resposne: Id of updated Loan
      
    - Orders
    
        - Get All Orders
            [View detail](https://sandbox.reggora.io/#get-all-orders)
            ```
                uint Offset = 0;
                uint Limit = 0;
                string ordering = "-created";
                string loanOfficer = null;
                string filters = "";
          
                List<Order> orders = lender.Orders.All(Offset, limit, ordering, loanOfficer);
            ```
            Response: List of `Order`
            
        - Get an Order
            [View detail](https://sandbox.reggora.io/#get-order)
            ```
                Order order = lender.Orders.Get(string orderId);
            ```
          
        - Cancel Order
            [View detail](https://sandbox.reggora.io/#cancel-order)
            ```
                string response = lender.Orders.Cancel(string orderId);
            ```
            Response: "Order has been canceled."

        - Create an Order
            [View detail](https://sandbox.reggora.io/#create-an-order)
            ```
                ** AllocationMode: Automatic, Manual **
                ** PriorityType: Normal, Rush **
          
                Order order = new Order()
                            {
                                Allocation = Order.AllocationMode.Automatic,
                                Loan = loanId,
                                Priority = Order.PriorityType.Normal,
                                ProductIds = productIds,
                                Due = DateTime.Now.AddYears(1)
                            };
                
                string response = lender.Orders.Create(order);
            ```
			Response: Id of created Order
          
        - Edit an Order
            [View detail](https://sandbox.reggora.io/#edit-an-order)
            ```
				** AllocationMode: Automatic, Manual **
                ** PriorityType: Normal, Rush **

                order.Priority = Order.PriorityType.Rush;
                lender.Orders.Edit(order);
            ```
			Response: Id of updated Order
            
        - Place Order On Hold
            [View detail](https://sandbox.reggora.io/#place-order-on-hold)
            ```
                string response = lender.Orders.OnHold(orderId, reason);
            ```
			Response: "Order has been updated"
          
        - Remove Order Hold
            [View detail](https://sandbox.reggora.io/#remove-order-hold)
            ```
                string response = lender.Orders.RemoveHold(orderId);
            ```
			Response: "Order has been updated"
          
    - eVault
    
        - Get eVault by ID
            [View detail](https://sandbox.reggora.io/#get-evault-by-id)
            ```
                Evault evault = lender.Evaults.Get(evaultId);
            ```
        
        - Get Document
            [View detail](https://sandbox.reggora.io/#get-document)
            ```
                lender.Evaults.GetDocument(evaultId, documentId);
            ```
			Response: File object of document
          
        - Upload Document
            [View detail](https://sandbox.reggora.io/#upload-document)
            ```
                string evaultId = "5d4d06d6d28c2600109499c5";
                string documentFilePath = "F:\document.pdf";
                
                string response = lender.Evaults.UploadDocument(evaultId, documentFilePath);
            ```
			Response: Id of uploaded document
        
        - Upload P&S
            [View detail](https://sandbox.reggora.io/#upload-p-amp-s)
            ```
                string orderId = "5d5bc544586cbb000f5e171f";
                string documentFilePath = "F:\document.pdf";
                
                string response = lender.Evaults.UploadDocument(evaultId, documentFilePath);
            ```  
			Response: Id of uploaded P&S document
          
        - Delete Document
            [View detail](https://sandbox.reggora.io/#delete-document)
            ```
                string response = lender.Evaults.DeleteDocument(evaultId, documentId);
            ```  
			Response: "Your document has been deleted"
         
	- Products
			
		- Get All Products
			[View detail](https://sandbox.reggora.io/#get-all-products)
			```
			    List<Product> products = lender.Products.All();
			```
			Response: List of `Product`

		- Get a Product
			[View detail](https://sandbox.reggora.io/#get-product)
			```
			    Product product = lender.Products.Get(productId);
			```

		- Delete Product
			[View detail](https://sandbox.reggora.io/#delete-product)
			```
			    string response = lender.Products.Delete(productId);
			```
			Response: "Your product has been deleted"

        - Create a Product
            [View detail](https://sandbox.reggora.io/#create-a-product)
            ```
                ** InspectionType: Interior, Exterior **
                Product product = new Product()
                                {
                                    ProductName = "Full Appraisal",
                                    Amount = 100.00f,
                                    InspectionType = Product.Inspection.Interior,
                                    RequestForms = "1004MC, BPO"
                                };
        
                string response = lender.Products.Create(product);
            ```
            Response: Id of created product
            
        - Edit a Product
            [View detail](https://sandbox.reggora.io/#edit-a-product)
            ```
                product.ProductName = newProductName;
                string response = lender.Products.Edit(product);
            ```
            Response: Id of updated product

	- Submissions
		
        - Get All Submissions
            [View detail](https://sandbox.reggora.io/#get-all-submissions)
            ```
                string orderId = "5d5bc544586cbb000f5e171f";
                List<Submission> submissions = lender.Orders.Submissions(orderId);
            ```
            Response: List of `Submission`
    
        - Download Submission Document
            [View detail](https://sandbox.reggora.io/#download-submission-document)
            ```
                ** reportType: "pdf_report", "xml_report", "invoice"
                string orderId = "5d5bc544586cbb000f5e171f";
                uint version = 1;
                string reportType = "pdf_report";
    
                string downloadPath = null; // If downloadPath is `null`, document will be download `Downloads` path by default
    
                bool response = lender.Orders.DownloadSubmissionDoc(orderId, version, reportType, downloadPath);
            ```
            Response: If downloaded successfully, `true`, otherwise, `false`

	- Users
		
        - Get All Users
            [View details](https://sandbox.reggora.io/#get-all-users)
            ```
                List<User> users = lender.Users.All();
            ```
            Response: List of `User`
    
        - Get User By ID
            [View detail](https://sandbox.reggora.io/#get-user-by-id)
            ```
                User user = lender.Users.Get(expectedId);
            ```
    
        - Invite User
            [View detail](https://sandbox.reggora.io/#invite-user)
            ```
                User user = new User()
                        {
                            Email = "user@email.com",
                            PhoneNumber = "12345678",
                            FirstName = "Fake",
                            LastName = "Person",
                            Role = "Admin"
                        };
    
                string response = lender.Users.Invite(user);
            ```
            Response: "Your invite has been sent"
    
        - Create User
            [View detail](https://sandbox.reggora.io/#create-user)
            ```
                User user = new User()
                        {
                            Email = "user@email.com",
                            PhoneNumber = "12345678",
                            FirstName = "Fake",
                            LastName = "Person",
                            NmlsId = "MA",
                            Role = "Admin"
                        };
    
                string response = lender.Users.Create(user);
            ```
            Response: Id of created user
    
        - Edit User
            [View detail](https://sandbox.reggora.io/#edit-user)
            ```
                string response = lender.Users.Edit(userId);
            ```
            Response: Id of updated user
    
        - Delete User
            [View detail](https://sandbox.reggora.io/#delete-user)
            ```
                string response = lender.Users.Delete(deleteId);
            ```
            Response: "Your user has been deleted"

	- Vendors
		
        - Get All Vendors
            [View detail](https://sandbox.reggora.io/#get-all-vendors)
            ```
                var vendors = lender.Vendors.All();
            ```
    
        - Get Vendors By Zone
            [View detail](https://sandbox.reggora.io/#get-vendors-by-zone)
            ```
                List<string> zones = new List<string> { "02806", "02807", "03102" };
                uint offset = 0;
                uint limit = 0;
                string ordering = "-created";
                List<Vendr> vendors = lender.Vendors.GetByZone(zones, offset, limit, ordering);
            ```
            Response: List of `Vendr`
    
        - Get Vendors By Branch
            [View detail](https://sandbox.reggora.io/#get-vendors-by-branch)
            ```
                List<Vendr> vendors = lender.Vendors.GetByBranch(branchId);
            ```
            Response: List of `Vendr`
    
        - Get Vendor By ID
            [View detail](https://sandbox.reggora.io/#get-vendor-by-id)
            ```
                Vendr vendor = lender.Vendors.Get(vendorId);
            ```
    
        - Add Vendor
            [View detail](https://sandbox.reggora.io/#add-vendor)
            ```
                Vendr vendor = new Vendr()
                        {
                            FirmName = "Appraisal Firm",
                            Email = "vendor@email.com",
                            Phone = "12345678",
                            FirstName = "Fake",
                            LastName = "Vendor"
                        };
    
                string response = lender.Vendors.Create(vendor);
            ```
            Response: Id of added vendor
    
        - Edit Vendor
            [View detail](https://sandbox.reggora.io/#edit-vendor)
            ```
                vendor.Phone = newPhoneNumber;
    
                string response = lender.Vendors.Edit(vendor);
            ```
            Response: Id of updated vendor
    
        - Delete Vendor
            [View detali](https://sandbox.reggora.io/#delete-vendor)
            ```
                string resposne = lender.Vendors.Delete(deleteId);
            ```
            Resposne: "Your vendor has been removed"

	- Schedule & Payment App
		
        - Send Payment App
            [View detail](https://sandbox.reggora.io/#send-payment-app)
            ```
                ** UsrType: Manual, Consumer **
                ** PaymenType: Manual, Stripe ** 
    
                PaymentApp app = new PaymentApp()
                            {
                                ConsumerEmail = "user@email.com",
                                OrderId = "5c33c6b1681f110034effc72",
                                UsrType = PaymentApp.UserType.Manual,
                                PaymenType = PaymentApp.PaymentType.Manual,
                                Amount = 100.00f,
                                FirstName = "Fake",
                                LastName = "Person",
                                Paid = false
                            };
    
                string rsponse = lender.Apps.SendPaymentApp(app);
            ```
            Response = "Payment app sent."
    
        - Send Scheduling App
            [View detail](https://sandbox.reggora.io/#send-scheduling-app)
            ```
                List<string> consumerEmails = new List<string> { "example@consumer.com"};
                string orderId = "5c33c6b1681f110034effc72";
    
                string response = lender.Apps.SendSchedulingApp(consumerEmails, orderId);
            ```
            Response: "Scheduling app sent."
        
        - Consumer Application Link
            [View detail](https://sandbox.reggora.io/#consumer-application-link)
            ```
                ** linkType: Payment, Scheduling, Both ** 
    
                string orderId = "5c33c6b1681f110034effc72";
                string consumerId = "5c33c716681f110034effc73";
                PaymentApp.LinkType linkType = PaymentApp.LinkType.Payment;
    
                string response = lender.Apps.ConsumerAppLink(orderId, consumerId, linkType);
            ```
            Response: "https://devconnect.reggora.com/schedule/.eJw1yjEOgCAMBdC7dJYE6i9WL2OAQuKgJBon492dfPN7qJ9Wz3UzWkiMUZoWnYMV-DFEFuSJaaDSj-ve_xgbGqvCcbLqoCZOq49OMhQhRUMN9H7l7hoK.B8-lmAvVwbOAqLz_-uzL8JIGXgA?iframe=true&override=payment"


				
## Usage for Vendor API

- Initializing Library
    
    ```c#
        private Vendor vendor = new Vendor(integrationToken);
        vendor.Authenticate(vendorUserName, vendorPassword); 
    ```

- Make a Request

	- Order Management
	
		- Get a Order By Id
            [View detail](https://sandbox.reggora.io/#vendor-get-order-by-id)
            ```
                string orderId = "5c2e718cb61f76001adf9871";
                VendorOrder order = vendor.VendorOrders.Get(orderId);
            ```
          
        - Get all Orders
            [View detail](https://sandbox.reggora.io/#vendor-get-all-orders)
            ```
                uint Offset = 0;
                uint Limit = 0;
                List<string> status = new List<string> { "created", "finding_appraisers", "accepted", "inspection_scheduled", "inspection_completed", "submitted", "revisions_requested" };
          
                var orders = vendor.VendorOrders.All(offset, limit, status);
            ```
            Response: List of `VendorOrder`
			
		- Accept Order
			[View detail](https://sandbox.reggora.io/#accept-order)
            ```
                string orderId = "5c2e718cb61f76001adf9871";
                string response = vendor.VendorOrders.VendorAcceptOrder(orderId);
            ```
            Response: Id of order

		- Counter Offer
			[View detail](https://sandbox.reggora.io/#counter-offer)
            ```
                string orderId = "5c2e718cb61f76001adf9871";
                DateTime dueDate = DateTime.Now.AddYears(1);
                float fee = 345.67f;
                string response = vendor.VendorOrders.CounterOffer(orderId, dueDate, fee);
            ```
            Response: Id of order

		- Deny Order
			[View detail](https://sandbox.reggora.io/#deny-order)
            ```
                string orderId = "5c2e718cb61f76001adf9871";
                string denyReason = "deny_reason': 'I am on vacation until next Tuesday";
                string response = vendor.VendorOrders.DenyOrder(orderId, denyReason);
            ```
            Response: Id of order

		- Set Inspection Date
			[View detail](https://sandbox.reggora.io/#set-inspection-date)
            ```
                string orderId = "5c2e718cb61f76001adf9871";
                DateTime inspectionDate = DateTime.Now.AddYears(1);
                string response = vendor.VendorOrders.SetInspectionDate(orderId, inspectionDate);
            ```
            Response: Id of order

		- Complete Inspection
			[View detail](https://sandbox.reggora.io/#complete-inspection)
            ```
                string orderId = "5c2e718cb61f76001adf9871";
                DateTime completedAt = DateTime.Now.AddYears(1);
                string response = vendor.VendorOrders.CompleteInspection(orderId, completedAt);
            ```
            Response: Id of order

		- Upload Submission
			[View detail](https://sandbox.reggora.io/#upload-submission)
            ```
                string orderId = "5c2e718cb61f76001adf9871";
                string pdfFile = "samplePdfFilePath";
                string xmlFile = "sampleXmlFilePath"; // optional
                string invoiceFile = "sampleInvoiceFile"; // Required if no invoiceNumber
                string invoiceNumber = null; // Required if no invoiceFile
    
                var response = vendor.VendorOrders.UploadSubmission(orderId, pdfFile, xmlFile, invoiceFile, invoiceNumber);
            ```
            Response: BASE64

		- Download Submission
            [View detail](https://sandbox.reggora.io/#download-submission)
            ```
                ** documentType: "pdf", "xml", "invoice"
                
                string orderId = "5c2e718cb61f76001adf9871";
                uint submissionVersion = 1;
                string documentType = "pdf"
                string downloadPath = null; // If downloadPath is `null`, document will be download `Downloads` path by default
                bool response = vendor.VendorOrders.DownloadSubmission(orderId, submissionVersion, documentType, downloadPath);
            ```
			Response: If downloaded successfully, `true`, otherwise, `false`

		- Vendor Cancel Order
			[View detail](https://sandbox.reggora.io/#vendor-cancel-order)
            ```
                string orderId = "5c2e718cb61f76001adf9871";
                string message = "I decided to quit the appraisal industry to follow my dreams of becoming a musician";
                string response = vendor.VendorOrders.VendorCancelOrder(orderId, message);
            ```
            Response: "This order has been cancelled"

	- Conversation Management

		- Get Conversation
            [View detail](https://sandbox.reggora.io/#get-conversation)
            ```
                string conversationId = "5c4f16764672bb00105ea5f9";
                Conversation conversation = vendor.Conversations.Get(conversationId);
            ```

		- Send Message
            [View detail](https://sandbox.reggora.io/#send-message)
            ```
                string conversationId = "5c4f16764672bb00105ea5f9";
                string message = "Don't you just love reggora?";
                var response = vendor.Conversations.SendMessage(conversationId, message);
            ```
			Response: Id of conversation
 
	- eVault Management

        - Vendor Get eVault by ID
            [View detail](https://sandbox.reggora.io/#vendor-get-evault-by-id)
            ```
                string evaultId = "5c4f16764672bb00105ea5f9";
                VendorEvault evault = vendor.Evaults.Get(evaultId);
            ```
        - Vendor Get Document
            [View detail](https://sandbox.reggora.io/#vendor-get-document)
            ```
                string documentId = "24bab39a-4404-11e8-ba10-02420a050006";
                string evaultId = "5c4f16764672bb00105ea5f9";
                string downloadPath = null;
                bool response = vendor.Evaults.GetDocument(evaultId, documentId, downloadPath);
            ```
            Response: If downloaded successfully, `true`, otherwise, `false`

		- Vendor Upload Document
            [View detail](https://sandbox.reggora.io/#vendor-upload-document)
            ```
                string evaultId = "5c4f16764672bb00105ea5f9";
                string file = "sample.pdf";
                string fileName = "SampleFile"; // optional
    
                string response = vendor.Evaults.UploadDocument(evaultId, file, fileName);
            ```
			Response: Id of uploaded document

		- Vendor Delete Document
            [View detail](https://sandbox.reggora.io/#vendor-delete-document)
            ```
                string evaultId = "5c4f16764672bb00105ea5f9";
                string documentId = "24bab39a-4404-11e8-ba10-02420a050006";
                response = vendor.Evaults.DeleteDocument(evaultId, documentId);
            ```
			Response: "Your document has been deleted"