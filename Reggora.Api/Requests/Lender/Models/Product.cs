using System.Collections.Generic;

namespace Reggora.Api.Requests.Lender.Models
{
    public class Product
    {
        public string Id;
        public string ProductName;
        public float Amount;
        public Inspection InspectionType;
        public List<string> RequestForms;
        public IDictionary<string, float> GeographicPricing = new Dictionary<string, float>();

        public enum Inspection
        {
            Interior,
            Exterior
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
    }
}