using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reggora.Api.Entity;
using Reggora.Api;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Reflection;
using System.Text;
using Reggora.Api.Requests.Lender.Products;

namespace ReggoraLenderApi.Test
{
    [TestClass]
    public class ReggoraTest
    {
        private Lender lender;

        [TestInitialize]
        public void Initialize()
        {
            if (lender == null)
            {
                lender = new Lender(Config.GetProperty("lender.token", ""));
                Console.WriteLine("Authenticating...");
                lender.Authenticate(Config.GetProperty("lender.email", ""), Config.GetProperty("lender.password", ""));
            }
        }

        public string RandomString(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            return builder.ToString();
        }

        public string RandomNumber(int startNum = 100000, int endNum = 999999)
        {
            Random rnd = new Random();
            int rand = rnd.Next(startNum, endNum);
            return rand.ToString();
        }

        // Test Loan Requests
        public string CreateLoan()
        {
            if (SampleObjects._loan != null) { return SampleObjects._loan.Id; }
            Loan loan = new Loan()
            {
                Number = RandomString(7, false),
                Type = "FHA",
                Due = DateTime.Now.AddYears(1),
                PropertyAddress = "100 Mass Ave",
                PropertyCity = "Boston",
                PropertyState = "MA",
                PropertyZip = "02192",
                CaseNumber = "10029MA",
                AppraisalType = "Refinance"
            };

            try
            {
                string createdLoanId = lender.Loans.Create(loan);
                SampleObjects._loan = lender.Loans.Get(createdLoanId);
                return createdLoanId;
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }

        }
        
        [TestMethod]
        public void A_TestCreateLoan()
        {
            Console.WriteLine("Testing Loan Requests...");
            string createdLoanId = CreateLoan();

            Assert.IsNotNull( createdLoanId, "Expected an ID of new Loan");
            
        }

        [TestMethod]
        public void B_TestGetLoans()
        {
            var loans = lender.Loans.All();
            Assert.IsInstanceOfType(loans, typeof(List<Loan>));
        }

        [TestMethod]
        public void C_TestGetLoan()
        {
            string expectedId = CreateLoan() ?? "5d56720d6dcf6d000d6e902c";
            Loan loan = lender.Loans.Get(expectedId);
            Assert.AreEqual(expectedId, loan.Id, String.Format("Tried to get loan by ID:'{0}'; Actual ID of loan: {1}",
                                     expectedId, loan.Id));
        }

        [TestMethod]
        public void D_TestEditLoan()
        {
            CreateLoan();
            Loan testLoan = SampleObjects._loan;
            
            string newLoanNumber = RandomString(7, false);

            testLoan.Number = newLoanNumber;
            try
            {
                string updatedLoanId = lender.Loans.Edit(testLoan);
                testLoan = lender.Loans.Get(updatedLoanId);
                SampleObjects._loan = testLoan;
                Assert.AreEqual(testLoan.Number, newLoanNumber, String.Format("Expected Loan Number:'{0}'; Loan Number: {1}",
                                     newLoanNumber, testLoan.Number));
               
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }

        [TestMethod]
        public void E_TestDeleteLoan()
        {
            string deleteId = CreateLoan() ?? "5d56720d6dcf6d000d6e902c";
            string response = lender.Loans.Delete(deleteId);
            SampleObjects._loan = null;
            Assert.IsNotNull(response, String.Format("Expected Success message of Deletion, Actual: {0}", response));

        }

        // Test Order Requests
        public string CreateOrder()
        {
            CreateLoan();
            CreateProduct();
            if (SampleObjects._order != null) { return SampleObjects._order.Id; }
            
            List<string> products = new List<string>();
            products.Add(SampleObjects._product.Id);
            Order order = new Order()
            {
                Allocation = Order.AllocationMode.Automatic,
                Loan = SampleObjects._loan.Id,
                Priority = Order.PriorityType.Normal,
                ProductIds = products,
                Due = DateTime.Now.AddYears(1)
            };

            try
            {
                string createdOrderId = lender.Orders.Create(order);
                SampleObjects._order = lender.Orders.Get(createdOrderId);
                return createdOrderId;
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }
        [TestMethod]
        public void A_TestCreateOrder()
        {
            Console.WriteLine("Testing Order Requests...");
            string createdOrderId = CreateOrder();

            Assert.IsNotNull(createdOrderId, "Expected an ID of new Order");
        }

        [TestMethod]
        public void B_TestGetOrders()
        {
            var orders = lender.Orders.All();
            Assert.IsInstanceOfType(orders, typeof(List<Order>));
        }

        [TestMethod]
        public void C_TestGetOrder()
        {
            Console.WriteLine("Testing Get a Loan...");
            string expectedId = CreateOrder() ?? "5d5bc544586cbb000f5e171f";
            Order order = lender.Orders.Get(expectedId);
            Assert.AreEqual(expectedId, order.Id, String.Format("Tried to get order by ID:'{0}'; Actual ID of order: {1}",
                                     expectedId, order.Id));
        }

        [TestMethod]
        public void D_TestEditOrder()
        {
            CreateOrder();
            Order testOrder = SampleObjects._order;

            DateTime newDueDate = DateTime.Now.AddYears(1);

            testOrder.Due = newDueDate;
            try
            {
                string updatedOrderId = lender.Orders.Edit(testOrder);
                testOrder = lender.Orders.Get(updatedOrderId);
                SampleObjects._order = testOrder;
                Assert.AreEqual(testOrder.Due, newDueDate, String.Format("Expected Loan Number:'{0}'; Loan Number: {1}",
                                     newDueDate.ToString(), testOrder.Due.ToString()));

            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }

        [TestMethod]
        public void E_TestCancelOrder()
        {
            string cancelId = CreateOrder() ?? "5d5bc544586cbb000f5e171f";
            string response = lender.Orders.Cancel(cancelId);
            SampleObjects._order = null;
            Assert.IsNotNull(response, String.Format("Expected Success message of Deletion, Actual: {0}", response));

        }

        [TestMethod]
        public void F_TestPlacelOrderOnHold()
        {
            string orderId = CreateOrder() ?? "5d5bc544586cbb000f5e171f";
            string reason = "I'd like to wait to start this order.";
            string response = lender.Orders.OnHold(orderId, reason);
            SampleObjects._order = null;
            Assert.IsNotNull(response, String.Format("Expected Success message of Placing Order On Hold, Actual: {0}", response));

        }

        [TestMethod]
        public void G_RemoveOrderHold()
        {
            string orderId = CreateOrder() ?? "5d5bc544586cbb000f5e171f";
            string response = lender.Orders.RemoveHold(orderId);
            SampleObjects._order = null;
            Assert.IsNotNull(response, String.Format("Expected Success message of Removing Order Hold, Actual: {0}", response));

        }

        [TestMethod]
        public void H_TestGetSubmissions()
        {
            string orderId = CreateOrder() ?? "5d5bc544586cbb000f5e171f";
            var submissions = lender.Orders.Submissions(orderId);
            Assert.IsInstanceOfType(submissions, typeof(List<Submission>));
        }

        //Test Product Requests
        public string CreateProduct()
        {
            if (SampleObjects._product != null) { return SampleObjects._product.Id; }
            Product product = new Product()
            {
                ProductName = "Full Appraisal" + RandomString(3, true),
                Amount = 100.00f,
                InspectionType = Product.Inspection.Interior,
                RequestForms = "1004MC, BPO"
            };
            try
            {
                string createdProductId = lender.Products.Create(product);
                SampleObjects._product = lender.Products.Get(createdProductId);
                return createdProductId;
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }

        [TestMethod]
        public void A_TestCreateProduct()
        {
            Console.WriteLine("Testing Product Requests...");
            string createdProductId = CreateProduct();

            Assert.IsNotNull(createdProductId, "Expected an ID of new Product");
        }

        [TestMethod]
        public void B_TestGetProducts()
        {
            var products = lender.Products.All();
            Assert.IsInstanceOfType(products, typeof(List<Product>));
        }

        [TestMethod]
        public void C_TestGetProduct()
        {
            string expectedId = CreateProduct() ?? "5d4bd10434e305000c322368";
            Product product = lender.Products.Get(expectedId);
            Assert.AreEqual(expectedId, product.Id, String.Format("Tried to get product by ID:'{0}'; Actual ID of product: {1}",
                                     expectedId, product.Id));
        }

        [TestMethod]
        public void D_TestEditProduct()
        {
            CreateProduct();
            Product testProduct = SampleObjects._product;

            string newProductName = RandomString(7, false);

            testProduct.ProductName = newProductName;
            try
            {
                string updatedProductId = lender.Products.Edit(testProduct);
                testProduct = lender.Products.Get(updatedProductId);
                SampleObjects._product = testProduct;
                Assert.AreEqual(testProduct.ProductName, newProductName, String.Format("Expected Product Name:'{0}'; Actual Product Name: {1}",
                                     newProductName, testProduct.ProductName));
                
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }

        [TestMethod]
        public void E_TestDeleteProduct()
        {
            string deleteId = CreateProduct() ?? "5d4bd10434e305000c322368";
            string response = lender.Products.Delete(deleteId);
            SampleObjects._product = null;
            Assert.IsNotNull(response, String.Format("Expected Success message of Deletion, Actual: {0}", response));

        }

        // Test User Requests
        public string CreateUser()
        {
            if (SampleObjects._user != null) { return SampleObjects._user.Id; }
            User user = new User()
            {
                Email = RandomString(4, true) + "@test.com",
                PhoneNumber = RandomNumber(),
                FirstName = "Fake",
                LastName = "Person" + RandomString(3, true),
                NmlsId = "MA",
                Role = "Admin"
            };

            try
            {
                string createdUserId = lender.Users.Create(user);
                SampleObjects._user = lender.Users.Get(createdUserId);
                return createdUserId;
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }

        [TestMethod]
        public void A_TestCreateUser()
        {
            Console.WriteLine("Testing User Requests...");
            string createdLoanId = CreateUser();

            Assert.IsNotNull(createdLoanId, "Expected an ID of new User");

        }

        [TestMethod]
        public void B_TestGetUsers()
        {
            var users = lender.Users.All();
            Assert.IsInstanceOfType(users, typeof(List<User>));
        }

        [TestMethod]
        public void C_TestGetUser()
        {
            string expectedId = CreateUser() ?? "5d5aa161cf56d4000de82465";
            User user = lender.Users.Get(expectedId);
            Assert.AreEqual(expectedId, user.Id, String.Format("Tried to get user by ID:'{0}'; Actual ID of user: {1}",
                                     expectedId, user.Id));
        }

        [TestMethod]
        public void D_TestEditUser()
        {
            CreateUser();
            User testUser = SampleObjects._user;

            string newPhoneNumber = RandomNumber();

            testUser.PhoneNumber = newPhoneNumber;
            try
            {
                string updatedUserId = lender.Users.Edit(testUser);
                testUser = lender.Users.Get(updatedUserId);

                SampleObjects._user = testUser;
                Assert.AreEqual(testUser.PhoneNumber, newPhoneNumber, String.Format("Expected User Phone Number:'{0}'; Actual Phone Number: {1}",
                                     newPhoneNumber, testUser.PhoneNumber));
                
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }

        [TestMethod]
        public void E_TestDeleteUser()
        {
            string deleteId = CreateUser() ?? "5d5aa161cf56d4000de82465";
            string response = lender.Users.Delete(deleteId);
            SampleObjects._user = null;
            Assert.IsNotNull(response, String.Format("Expected Success message of Deletion, Actual: {0}", response));

        }

        [TestMethod]
        public void A_TestInviteUser()
        {
            User user = new User()
            {
                Email = RandomString(4, false) + "@test.com",
                PhoneNumber = RandomNumber(),
                FirstName = "Fake",
                LastName = "Person" + RandomString(3, true),
                Role = "Admin"
            };
            try
            {
                string response = lender.Users.Invite(user);

                Assert.IsNotNull(response, String.Format("Expected Success message of Invitation, Actual: {0}", response));
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }


        //Test Vendor Requests
        public string CreateVendor()
        {
            if(SampleObjects._vendor != null) { return SampleObjects._vendor.Id; }
            Vendr vendor = new Vendr()
            {
                FirmName = "Appraisal Firm" + RandomNumber(1000, 10000),
                Email = "vendor_" + RandomString(4, true) + "@test.com",
                Phone = RandomNumber(),
                FirstName = "Fake",
                LastName = "Vendor" + RandomString(3, true)
            };
            try
            {
                string createdVendorId = lender.Vendors.Create(vendor);
                SampleObjects._vendor = lender.Vendors.Get(createdVendorId);
                return createdVendorId;
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }

        [TestMethod]
        public void A_TestCreateVendor()
        {
            Console.WriteLine("Testing Vendor Requests...");
            string createdVendorId = CreateVendor();

            Assert.IsNotNull(createdVendorId, "Expected an ID of new Vendor");
        }

        [TestMethod]
        public void B_TestGetVendors()
        {
            var vendors = lender.Vendors.All();
            Assert.IsInstanceOfType(vendors, typeof(List<Vendr>));
        }

        [TestMethod]
        public void C_TestGetVendor()
        {
            string expectedId = CreateVendor() ?? "5d5b714c586cbb000d3eecb5";
            Vendr vendor = lender.Vendors.Get(expectedId);
            Assert.AreEqual(expectedId, vendor.Id, String.Format("Tried to get vendor by ID:'{0}'; Actual ID of vendor: {1}",
                                     expectedId, vendor.Id));
        }

        [TestMethod]
        public void B_TestGetVendorsByZones()
        {
            List<string> zones = new List<string> {};
            var vendors = lender.Vendors.GetByZone(zones);
            Assert.IsInstanceOfType(vendors, typeof(List<Vendr>));
        }

        [TestMethod]
        public void B_TestGetVendorsByBranch()
        {
            string branchId = "5b58c8861e5f59000d4542af";
            var vendors = lender.Vendors.GetByBranch(branchId);
            Assert.IsInstanceOfType(vendors, typeof(List<Vendr>));
        }

        [TestMethod]
        public void D_TestEditVendor()
        {
            CreateVendor();
            Vendr testVendor = SampleObjects._vendor;

            string newPhone = RandomNumber();

            testVendor.Phone = newPhone;
            try
            {
                string updatedVendorId = lender.Vendors.Edit(testVendor);
                testVendor = lender.Vendors.Get(updatedVendorId);

                SampleObjects._vendor = testVendor;
                Assert.AreEqual(testVendor.Phone, newPhone, String.Format("Expected Phone number:'{0}'; Actual Phone number: {1}",
                                     newPhone, testVendor.Phone));
                
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }

        [TestMethod]
        public void E_TestDeleteVendor()
        {
            string deleteId = CreateVendor() ?? "5d5b714c586cbb000d3eecb5";
            string response = lender.Vendors.Delete(deleteId);
            SampleObjects._vendor = null;
            Assert.IsNotNull(response, String.Format("Expected Success message of Deletion, Actual: {0}", response));

        }

        // Schedule and Payment App Requests

        [TestMethod]
        public void A_SendPaymentApp()
        {
            CreateUser();
            CreateOrder();

            PaymentApp app = new PaymentApp()
            {
                ConsumerEmail = SampleObjects._user.Email,
                OrderId = SampleObjects._order.Id,
                UsrType = PaymentApp.UserType.Manual,
                PaymenType = PaymentApp.PaymentType.Manual,
                Amount = 100.00f,
                FirstName = "Fake",
                LastName = "Person" + RandomString(3, true),
                Paid = false
            };

            try
            {
                string response = lender.Apps.SendPaymentApp(app);
                Assert.IsNotNull(response, String.Format("Expected Success message of Sending Payment , Actual: {0}", response));
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }

        [TestMethod]
        public void B_SendSchedulingApp()
        {
            CreateUser();
            CreateOrder();
            string orderId = SampleObjects._order.Id;
            List<string> consumerEmails = new List<string> { };
            consumerEmails.Add(SampleObjects._user.Id);

            try
            {
                string response = lender.Apps.SendSchedulingApp(consumerEmails, orderId);
                Assert.IsNotNull(response, String.Format("Expected Success message of Sending Scheduling App, Actual: {0}", response));
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }

        [TestMethod]
        public void C_ConsumerAppLink()
        {
            CreateUser();
            CreateOrder();
            string orderId = SampleObjects._order.Id;
            string consumerId = SampleObjects._user.Id;
            PaymentApp.LinkType linkType = PaymentApp.LinkType.Payment;
            try
            {
                string response = lender.Apps.ConsumerAppLink(orderId, consumerId, linkType);
                Assert.IsNotNull(response, String.Format("Expected Success message of Getting Consumer Application Link, Actual: {0}", response));
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }
    }

    public class SampleObjects
    {
        public static Loan _loan { get; set; }
        public static Order _order { get; set; }
        public static Product _product { get; set; }
        public static User _user { get; set; }
        public static Vendr _vendor { get; set; }

    }

    public class Config
    {
        public static string ConfigFileName = "example.conf";
        private static IReadOnlyDictionary<string, string> KeyValues { get; set; }

        static Config()
        {
            try
            {
                string username = Environment.UserName;

                string fileContents = string.Empty;
                string path = System.AppDomain.CurrentDomain.BaseDirectory;
                if (path != null)
                {
                    var configFilePath = Path.Combine(path, $"example.{username}.conf");
                    if (File.Exists(configFilePath))
                    {
                        fileContents = File.ReadAllText(configFilePath);
                        Console.WriteLine($"Using config at {configFilePath}");
                    }
                    else
                    {
                        configFilePath = Path.Combine(path, ConfigFileName);

                        if (File.Exists(configFilePath))
                        {
                            fileContents = File.ReadAllText(configFilePath);
                            Console.WriteLine($"Using config at {configFilePath}");
                        }
                    }
                }

                LoadValues(fileContents);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error configuring parser");
                Console.WriteLine(e.Message);
            }
        }

        private static void LoadValues(string data)
        {
            Dictionary<string, string> newDictionairy = new Dictionary<string, string>();
            foreach (
                string rawLine in data.Split(new[] { "\r\n", "\n", Environment.NewLine },
                    StringSplitOptions.RemoveEmptyEntries))
            {
                string line = rawLine.Trim();
                if (line.StartsWith("#") || !line.Contains("=")) continue; //It's a comment or not a key value pair.

                string[] splitLine = line.Split('=', 2);

                string key = splitLine[0].ToLower();
                string value = splitLine[1];
                if (!newDictionairy.ContainsKey(key))
                {
                    newDictionairy.Add(key, value);
                }
            }

            KeyValues = new ReadOnlyDictionary<string, string>(newDictionairy);
        }

        public static Boolean GetProperty(string property, bool defaultValue)
        {
            try
            {
                string d = ReadString(property);
                if (d == null) return defaultValue;

                return Convert.ToBoolean(d);
            }
            catch
            {
                return defaultValue;
            }
        }

        public static int GetProperty(string property, int defaultValue)
        {
            try
            {
                var value = ReadString(property);
                if (value == null) return defaultValue;

                return Convert.ToInt32(value);
            }
            catch
            {
                return defaultValue;
            }
        }

        public static string GetProperty(string property, string defaultValue)
        {
            return ReadString(property) ?? defaultValue;
        }

        private static string ReadString(string property)
        {
            property = property.ToLower();
            if (!KeyValues.ContainsKey(property)) return null;
            return KeyValues[property];
        }
    }

}
