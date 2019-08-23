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
 - Once building done, you can see the library `Reggora.Api.dll` in `Reggora.Api\bin\Release\netcoreapp2.2` directory.
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
      
            `var loans = lender.Loans.All(uint Offset = 0, uint Limit = 0, string Ordering = "-created", string LoanOfficer = null);`
        
        - Get a Loan
      
            `Loan loan = lender.Loans.Get(string loanId);`
        
        - Delete a Loan
        
            `lender.Loans.Delete(string loanId);`
            
        - Create a Loan
        
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
      
            ```
                loan.Number = "newLoanNumber";
                lender.Loans.Edit(loan);
            ```