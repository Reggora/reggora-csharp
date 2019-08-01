using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Reflection;
using Reggora.Api.Exceptions;
using Reggora.Api.Requests.Lender.Models;

namespace Reggora.Api.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Lender();
            Vendor();
        }

        public static void Lender()
        {
            Lender lender = new Lender(Config.GetProperty("lender.token", ""));
            try
            {
                lender.Authenticate(Config.GetProperty("lender.email", ""),
                    Config.GetProperty("lender.password", ""));
            }
            catch (ReggoraException e)
            {
                Console.WriteLine("Unable to authenticate to lender API: " + e.Message);
                return;
            }

//            try
//            {
//                var loanId = lender.CreateLoan(new Loan
//                {
//                    LoanNumber = "5b3bbfdb4348380ddc56cd12",
//                    AppraisalType = "refinance",
//                    DueDate = "2019-09-27 10:10:46",
//                    SubjectPropertyAddress = "695 Atlantic St",
//                    SubjectPropertyCity = "Boston",
//                    SubjectPropertyState = "MA",
//                    SubjectPropertyZip = 02134
//                });
//
//                Loan loan = lender.Loan(loanId);
//
//                loan.LoanType = "FHA";
//                var updateLoan = lender.UpdateLoan(loan);
//
//                var deleteLoan = lender.DeleteLoan(loan);
//            }
//            catch (ReggoraException e)
//            {
//                Console.WriteLine("Unable to manage loans: " + e.Message);
//                return;
//            }
            
            try
            {
                var productId = lender.CreateProduct(new Product
                {
                    ProductName = "test product",
                    Amount = (float) 10.0,
                    InspectionType = Product.Inspection.Exterior,
                    RequestForms = new List<string> { "Form#1", "Form#2" }
                    
                });
                
                Console.WriteLine(productId);

//                Loan loan = lender.Loan(loanId);
//
//                loan.LoanType = "FHA";
//                var updateLoan = lender.UpdateLoan(loan);
//
//                var deleteLoan = lender.DeleteLoan(loan);
            }
            catch (ReggoraException e)
            {
                Console.WriteLine("Unable to manage products: " + e.Message);
                return;
            }

            return;
        }

        public static void Vendor()
        {
            Vendor vendor;
            try
            {
                vendor = Reggora.Vendor(Config.GetProperty("vendor.email", ""),
                    Config.GetProperty("vendor.password", ""), Config.GetProperty("vendor.token", ""));
            }
            catch (ReggoraException e)
            {
                Console.WriteLine("Unable to authenticate to vendor API: " + e.Message);
                return;
            }
        }
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
                string path = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
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
                string rawLine in data.Split(new[] {"\r\n", "\n", Environment.NewLine},
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