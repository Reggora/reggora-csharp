# Reggora

## Welcome to `Reggora` api!
### `Reggora C# library` works for `Lender` and `Vendor` APIs supported by [Reggora](https://sandbox.reggora.io/).

## Dependencies
- NuGet (5.2.0)
- NuGet Packages
 
  - MimeMapping v1.0.1.14
  - Newtonsoft.Json v12.0.2
  - RestSharp v106.6.10
  - RestSharp.Newtonsoft.Json v1.5.1
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
          
                var loans = lender.Loans.All(Offset, limit, ordering, loanOfficer);
            ```
        
        - Get a Loan
            [View detail](https://sandbox.reggora.io/#get-loan)
            ```
                Loan loan = lender.Loans.Get(string loanId);
            ```
        
        - Delete a Loan
            [View detail](https://sandbox.reggora.io/#delete-loan)
            ```
                lender.Loans.Delete(string loanId);
            ```
            
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
                lender.Loans.Create(loan);
            ```
        - Edit a Loan
            [View detail](https://sandbox.reggora.io/#edit-a-loan)
            ```
                loan.Number = "newLoanNumber";
                lender.Loans.Edit(loan);
            ```
      
    - Orders
    
        - Get All Orders
            [View detail](https://sandbox.reggora.io/#get-all-orders)
            ```
                uint Offset = 0;
                uint Limit = 0;
                string ordering = "-created";
                string loanOfficer = null;
                string filters = "";
          
                var orders = lender.Orders.All(Offset, limit, ordering, loanOfficer);
            ```
            
        - Get an Order
            [View detail](https://sandbox.reggora.io/#get-order)
            ```
                Order order = lender.Orders.Get(string orderId);
            ```
          
        - Cancel Order
            [View detail](https://sandbox.reggora.io/#cancel-order)
            ```
                lender.Orders.Cancel(string orderId);
            ```
            
        - Create an Order
            [View detail](https://sandbox.reggora.io/#create-an-order)
            ```
                Order order = new Order()
                            {
                                Allocation = Order.AllocationMode.Automatic,
                                Loan = loanId,
                                Priority = Order.PriorityType.Normal,
                                ProductIds = productIds,
                                Due = DateTime.Now.AddYears(1)
                            };
                
                lender.Orders.Create(order);
            ```
          
        - Edit an Order
            [View detail](https://sandbox.reggora.io/#edit-an-order)
            ```
                order.Priority = Order.PriorityType.Rush;
                lender.Orders.Edit(order);
            ```
            
        - Place Order On Hold
            [View detail](https://sandbox.reggora.io/#place-order-on-hold)
            ```
                lender.Orders.OnHold(orderId, reason);
            ```
          
        - Remove Order Hold
            [View detail](https://sandbox.reggora.io/#remove-order-hold)
            ```
                lender.Orders.RemoveHold(orderId);
            ```
          
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
          
        - Upload Document
            [View detail](https://sandbox.reggora.io/#upload-document)
            ```
                string evaultId = "5d4d06d6d28c2600109499c5";
                string documentFilePath = "F:\document.pdf";
                
                lender.Evaults.UploadDocument(evaultId, documentFilePath);
            ```
        
        - Upload P&S
            [View detail](https://sandbox.reggora.io/#upload-p-amp-s)
            ```
                string orderId = "5d5bc544586cbb000f5e171f";
                string documentFilePath = "F:\document.pdf";
                
                lender.Evaults.UploadDocument(evaultId, documentFilePath);
            ```  
                