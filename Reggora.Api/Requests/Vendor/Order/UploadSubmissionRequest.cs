using RestSharp;

namespace Reggora.Api.Requests.Vendor.Order
{
    public class UploadSubmissionRequest : ReggoraRequest
    {
        public UploadSubmissionRequest(string orderId, string pdfFilePath, string xmlFilePath, string invoiceFilePath, string invoiceNumber) : base("vendor/submission/{order_id}", Method.PUT)
        {

            AddParameter("order_id", orderId, ParameterType.UrlSegment);

            AddFile("pdf_file", pdfFilePath, MimeMapping.MimeUtility.GetMimeMapping(pdfFilePath));

            if (xmlFilePath != null)
            {
                AddFile("xml_file", xmlFilePath, MimeMapping.MimeUtility.GetMimeMapping(xmlFilePath));
            }

            if (invoiceFilePath != null)
            {
                AddFile("invoice_file", invoiceFilePath, MimeMapping.MimeUtility.GetMimeMapping(invoiceFilePath));
            }

            if (invoiceNumber != null)
            {
                AddParameter("invoice_number", invoiceNumber);
            }
        }
    }
}