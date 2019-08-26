using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reggora.Api;
using Reggora.Api.Entity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;

namespace ReggoraVendorApi.Test
{
    [TestClass]
    public class ReggoraTest
    {
        private Vendor vendor;
        private string orderId = "5d617e55e577d1000e90c996";
        private string evaultId = "5c4f16764672bb00105ea5f9";
        private string documentId = null;

        [TestInitialize]
        public void Initialize()
        {
            if (vendor == null)
            {
                vendor = new Vendor(Config.GetProperty("vendor.token", ""));
                Console.WriteLine("Authenticating...");
                vendor.Authenticate(Config.GetProperty("vendor.email", ""), Config.GetProperty("vendor.password", ""));
            }
        }
        

        [TestMethod]
        public void AA_TestGetVendorOrder()
        {
            Console.WriteLine("Testing Get a Order of vendor...");
            string expectedId = this.orderId;
            try
            {
                VendorOrder order = vendor.VendorOrders.Get(expectedId);
                Assert.AreEqual(expectedId, order.Id, String.Format("Tried to get order by ID:'{0}'; Actual ID of order: {1}",
                                         expectedId, order.Id));
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
            
        }

        [TestMethod]
        public void AB_TestGetVendorOrders()
        {
            uint offset = 0;
            uint limit = 0;

            List<string> status = new List<string> { "created", "finding_appraisers", "accepted", "inspection_scheduled", "inspection_completed", "submitted", "revisions_requested" };

            try
            {
                var orders = vendor.VendorOrders.All(offset, limit, status);
                Assert.IsInstanceOfType(orders, typeof(List<VendorOrder>));
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }

        [TestMethod]
        public void AC_TestAcceptVendorOrder()
        {
            string orderId = this.orderId;
            string response = vendor.VendorOrders.VendorAcceptOrder(orderId);
            
            Assert.IsNotNull(response, String.Format("Expected Success message of Accpetance, Actual: {0}", response));
        }

        [TestMethod]
        public void AD_TestCounterOffer()
        {
            string orderId = this.orderId;
            DateTime dueDate = DateTime.Now.AddYears(1);
            float fee = 345.67f;
            string response = vendor.VendorOrders.CounterOffer(orderId, dueDate, fee);

            Assert.AreEqual(orderId, response, String.Format("Counter Offer for Order['{0}']; Actual ID of response: {1}",
                                         orderId, response));
        }

        [TestMethod]
        public void AE_TestDenyOrder()
        {
            string orderId = this.orderId;
            string denyReason = "deny_reason': 'I am on vacation until next Tuesday";
            string response = vendor.VendorOrders.DenyOrder(orderId, denyReason);

            Assert.AreEqual(orderId, response, String.Format("Deny Order for Order['{0}']; Actual ID of response: {1}",
                                         orderId, response));
        }

        [TestMethod]
        public void AF_TestSetInspectionDate()
        {
            string orderId = this.orderId;
            DateTime inspectionDate = DateTime.Now.AddYears(1);
            string response = vendor.VendorOrders.SetInspectionDate(orderId, inspectionDate);

            Assert.AreEqual(orderId, response, String.Format("Setting Inspection Date for Order['{0}']; Actual ID of response: {1}",
                                         orderId, response));
        }

        [TestMethod]
        public void AG_TestCompleteInspection()
        {
            string orderId = this.orderId;
            DateTime completedAt = DateTime.Now.AddYears(1);
            string response = vendor.VendorOrders.CompleteInspection(orderId, completedAt);

            Assert.AreEqual(orderId, response, String.Format("Complete Inspection Date for Order['{0}']; Actual ID of response: {1}",
                                         orderId, response));
        }

        [TestMethod]
        public void AH_TestUploadSubmission()
        {
            string orderId = this.orderId;
            string path = AppDomain.CurrentDomain.BaseDirectory;
            string samplePdfFile = Path.Combine(path, "\\sample.pdf");
            string sampleXmlFile = Path.Combine(path, "\\sample.xml");
            string sampleInvoiceFile = Path.Combine(path, "\\sample.pdf");
            string invoiceNumber = null;

            try
            {
                var response = vendor.VendorOrders.UploadSubmission(orderId, samplePdfFile, sampleXmlFile, sampleInvoiceFile, invoiceNumber);
                Assert.IsNotNull(response);

            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }

        [TestMethod]
        public void AI_TestDownloadSubmissionDoc()
        {
            string orderId = this.orderId;
            uint submissionVersion = 1;
            string documentType = "pdf"; // "xml", "invoice"
            string downloadPath = null;
            bool response = vendor.VendorOrders.DownloadSubmission(orderId, submissionVersion, documentType, downloadPath);
            Assert.IsTrue(response);
        }

        [TestMethod]
        public void AJ_TestCancelVendorOrder()
        {
            string orderId = this.orderId;
            string message = "I decided to quit the appraisal industry to follow my dreams of becoming a musician";
            string response = vendor.VendorOrders.VendorCancelOrder(orderId, message);
            Assert.IsNotNull(response, String.Format("Expected Success message of Cancellation, Actual: {0}", response));

        }

        [TestMethod]
        public void BA_TestGetConverstion()
        {
            string conversationId = "5c4f16764672bb00105ea5f9";
            var conversation = vendor.Conversations.Get(conversationId);
            Assert.IsInstanceOfType(conversation, typeof(Conversation));

        }

        [TestMethod]
        public void BB_TestSendMessage()
        {
            string conversationId = "5c4f16764672bb00105ea5f9";
            string message = "Don't you just love reggora?";
            var response = vendor.Conversations.SendMessage(conversationId, message);
            Assert.AreEqual(conversationId, response, String.Format("Send Message for Conversation['{0}']; Actual ID of response: {1}",
                                         conversationId, response));

        }

        public string UploadDocument()
        {
            if (documentId != null)
            {
                return documentId;
            }
            string evaultId = this.evaultId;
            string path = AppDomain.CurrentDomain.BaseDirectory;
            string sampleFile = Path.Combine(path, "\\sample.pdf");
            string fileName = "SampleFile";

            try
            {
                string response = vendor.Evaults.UploadDocument(evaultId, sampleFile, fileName);
                documentId = response;

                return response;
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }

        [TestMethod]
        public void CA_TestGetEvault()
        {
            string evaultId = this.evaultId;
            var evault = vendor.Evaults.Get(evaultId);
            Assert.IsInstanceOfType(evault, typeof(VendorEvault));
        }

        [TestMethod]
        public void CB_TestGetDocument()
        {
            string documentId = UploadDocument();
            
            bool response = false;
            if (documentId != null)
            {
                string evaultId = this.evaultId;
                string downloadPath = null;
                response = vendor.Evaults.GetDocument(evaultId, documentId, downloadPath);
            }
            
            Assert.IsTrue(response);
        }

        [TestMethod]
        public void CC_TestUploadDocument()
        {
            string documentId = UploadDocument();
            Assert.IsNotNull(documentId, String.Format("Id of Uploaded document, Actual: {0}", documentId));
            
        }

        [TestMethod]
        public void CD_TestDeleteDocument()
        {
            string documentId = UploadDocument();
            string response = null;
            if(documentId != null)
            {
                string evaultId = this.evaultId;
                response = vendor.Evaults.DeleteDocument(evaultId, documentId);
            }
            Assert.IsNotNull(response, String.Format("Expected Success message of Deletion, Actual: {0}", response));
        }

    }


    public class SampleObjects
    {
        public static Loan _loan { get; set; }
        public static Order _order { get; set; }
        public static Product _product { get; set; }
        public static User _user { get; set; }
        public static Vendr _vendor { get; set; }
        public static Evault _evault { get; set; }

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
                string path = AppDomain.CurrentDomain.BaseDirectory;
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
