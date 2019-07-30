using System.Collections.Generic;

namespace Reggora.Api.Requests.Lender.Models
{
    public class Product
    {
        public string Id;
        public string ProductName;
        public float Amount;
        public string InspectionType = "";
        public string RequestForms = "";
        public IDictionary<string, float> GeographicPricing = new Dictionary<string, float>();
    }
}