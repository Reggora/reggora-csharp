using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reggora.Api.Entity;
using Reggora.Api;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Reflection;
using System.Text;

namespace ReggoraApi.Test
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

        [TestMethod]
        public void A_TestCreateLoan()
        {
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
            Assert.AreEqual(expectedId, loan.Id, String.Format("Tried to get land by ID:'{0}'; Actual ID of loan: {1}",
                                     expectedId, loan.Id));
        }

        [TestMethod]
        public void D_TestEditLoan()
        {
            if (SampleObjects._loan == null) { CreateLoan(); }
            Loan testLoan = SampleObjects._loan;
            
            string newLoanNumber = RandomString(7, false);
            
            Loan newLoan = new Loan(){ Id = testLoan.Id, Number = newLoanNumber};
            try
            {
                string updatedLoanId = lender.Loans.Edit(newLoan);
                newLoan = lender.Loans.Get(updatedLoanId);
               
                Assert.AreEqual(newLoan.Number, newLoanNumber, String.Format("Expected Loan Number:'{0}'; Loan Number: {1}",
                                     newLoanNumber, newLoan.Number));
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

    }

    public class SampleObjects
    {
        public static Loan _loan { get; set; }

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
