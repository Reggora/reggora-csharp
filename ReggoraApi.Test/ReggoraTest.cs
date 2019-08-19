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
        
        public string CreateLoan()
        {
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

        // Test Loan Requests
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
            if (SampleObjects._loan == null) { CreateLoan(); }
            Loan testLoan = SampleObjects._loan;
            string expectedId = testLoan != null ? testLoan.Id : "5d56720d6dcf6d000d6e902c";
            Loan loan = lender.Loans.Get(expectedId);
            Assert.AreEqual(expectedId, loan.Id, String.Format("Tried to get loan by ID:'{0}'; Actual ID of loan: {1}",
                                     expectedId, loan.Id));
        }

        [TestMethod]
        public void D_TestEditLoan()
        {
            if (SampleObjects._loan == null) { CreateLoan(); }
            Loan testLoan = SampleObjects._loan;
            
            string newLoanNumber = RandomString(7, false);

            testLoan.Number = newLoanNumber;
            try
            {
                string updatedLoanId = lender.Loans.Edit(testLoan);
                testLoan = lender.Loans.Get(updatedLoanId);
               
                Assert.AreEqual(testLoan.Number, newLoanNumber, String.Format("Expected Loan Number:'{0}'; Loan Number: {1}",
                                     newLoanNumber, testLoan.Number));
                SampleObjects._loan = testLoan;
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }

        [TestMethod]
        public void E_TestDeleteLoan()
        {
            if (SampleObjects._loan == null) { CreateLoan(); }
            Loan testLoan = SampleObjects._loan;

            string deleteId = testLoan != null ? testLoan.Id : "5d56720d6dcf6d000d6e902c";
            string response = lender.Loans.Delete(deleteId);
            SampleObjects._loan = null;
            Assert.IsNotNull(response, String.Format("Expected Success message of Deletion, Actual: {0}", response));

        }

        // Test Order Requests
        public string CreateOrder()
        {
            Order order = new Order()
            {
                Allocation = Order.AllocationMode.Automatic,
                Loan = SampleObjects._loan.Id,
                Priority = Order.PriorityType.Normal,
                Products = new string[]{ "5c49dcbb20cb8f002076039a" },
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
            CreateLoan();
            string createdOrderId = CreateOrder();

            Assert.IsNotNull(createdOrderId, "Expected an ID of new Order");
        }

        [TestMethod]
        public void B_TestGetOrder()
        {
            Console.WriteLine("Testing Get a Loan...");
            string orderId = "5d5a1480cf56d4000de82457";
            Order order = lender.Orders.Get(orderId);
            Assert.AreEqual(orderId, order.Id, String.Format("Tried to get order by ID:'{0}'; Actual ID of order: {1}",
                                     orderId, order.Id));
        }

        //Test Product Requests
        public string CreateProduct()
        {
            Product product = new Product()
            {
                ProductName = "Full Appraisal1",
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
            if (SampleObjects._product == null) { CreateProduct(); }
            Product testProduct = SampleObjects._product;
            string expectedId = testProduct != null ? testProduct.Id : "5d4bd10434e305000c322368";
            Product product = lender.Products.Get(expectedId);
            Assert.AreEqual(expectedId, product.Id, String.Format("Tried to get product by ID:'{0}'; Actual ID of product: {1}",
                                     expectedId, product.Id));
        }

        [TestMethod]
        public void D_TestEditProduct()
        {
            if (SampleObjects._product == null) { CreateProduct(); }
            Product testProduct = SampleObjects._product;

            string newProductName = RandomString(7, false);

            testProduct.ProductName = newProductName;
            try
            {
                string updatedProductId = lender.Products.Edit(testProduct);
                testProduct = lender.Products.Get(updatedProductId);

                Assert.AreEqual(testProduct.ProductName, newProductName, String.Format("Expected Product Name:'{0}'; Actual Product Name: {1}",
                                     newProductName, testProduct.ProductName));
                SampleObjects._product = testProduct;
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }

        [TestMethod]
        public void E_TestDeleteProduct()
        {
            if (SampleObjects._product == null) { CreateProduct(); }
            Product testProduct = SampleObjects._product;

            string deleteId = testProduct != null ? testProduct.Id : "5d4bd10434e305000c322368";
            string response = lender.Products.Delete(deleteId);
            SampleObjects._product = null;
            Assert.IsNotNull(response, String.Format("Expected Success message of Deletion, Actual: {0}", response));

        }
    }

    public class SampleObjects
    {
        public static Loan _loan { get; set; }
        public static Order _order { get; set; }
        public static Product _product { get; set; }

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
