using Reggora.Api.Entity;
using Reggora.Api.Requests.Vendor.Order;
using Reggora.Api.Util;
using Syroot.Windows.IO;
using System;
using System.Collections.Generic;
using System.IO;

namespace Reggora.Api.Storage.Vendor
{
    public class OrderManagementStorage : Storage<VendorOrder, Api.Vendor>
    {
        public OrderManagementStorage(Api.Vendor api) : base(api)
        {
        }

        public List<VendorOrder> All(uint offset = 0, uint limit = 0, List<string> Status = null)
        {
            string status = Status != null ? String.Join(",", Status.ToArray()) : null ;
            
            var result = new GetVendorOrdersRequest(offset, limit, status).Execute(Api.Client);
            var count = result.Data.Count;
            var fetchedOrders = result.Data.Orders;
            List<VendorOrder> orders = new List<VendorOrder>();

            if (result.Status == 200)
            {
                for (int i = 0; i < fetchedOrders.Count; i++)
                {
                    VendorOrder tempOrder = new VendorOrder();
                    tempOrder.UpdateFromRequest(Utils.DictionaryOfJsonFields(fetchedOrders[i]));
                    orders.Add(tempOrder);
                }
            }
            return orders;
        }

        public override VendorOrder Get(string id)
        {
            Known.TryGetValue(id, out var returned);

            if (returned == null)
            {
                var result = new GetVendorOrderRequest(id).Execute(Api.Client);
                if (result.Status == 200)
                {
                    returned = new VendorOrder();
                    returned.UpdateFromRequest(Utils.DictionaryOfJsonFields(result.Data));
                    Known.Add(returned.Id, returned);
                }
            }

            return returned;
        }

        public string VendorAcceptOrder(string orderId)
        {
            string response = "";
            var result = new AcceptVendorOrderRequest(orderId).Execute(Api.Client);
            if (result.Status == 200)
            {
                response = result.Data;
            }
            return response;
        }

        public string CounterOffer(string orderId, DateTime? dueDate, float? fee)
        {
            string response = "";
            var result = new CounterOfferRequest(orderId, dueDate, fee).Execute(Api.Client);
            if (result.Status == 200)
            {
                response = result.Data;
            }
            return response;
        }

        public string DenyOrder(string orderId, string denyReason = null)
        {
            string response = "";
            var result = new DenyOrderRequest(orderId, denyReason).Execute(Api.Client);
            if (result.Status == 200)
            {
                response = result.Data;
            }
            return response;
        }

        public string SetInspectionDate(string orderId, DateTime? inspectionDate)
        {
            string response = "";
            var result = new EditInspectionDateRequest(orderId, inspectionDate).Execute(Api.Client);
            if (result.Status == 200)
            {
                response = result.Data;
            }
            return response;
        }

        public string CompleteInspection(string orderId, DateTime? completedAt)
        {
            string response = "";
            var result = new CompleteInspectionRequest(orderId, completedAt).Execute(Api.Client);
            if (result.Status == 200)
            {
                response = result.Data;
            }
            return response;
        }

        public string UploadSubmission(string orderId, string pdfFilePath, string xmlFilePath = null, string invoiceFilePath = null, string invoiceNumber = null)
        {
            string response = null;
            var result = new UploadSubmissionRequest(orderId, pdfFilePath, xmlFilePath, invoiceFilePath, invoiceNumber).Execute(Api.Client);
            if (result.Status == 200)
            {
                response = result.Data;

            }

            return response;
        }

        public bool DownloadSubmission(string orderId, uint submissionVersion, string documentType, string downloadPath)
        {
            if (downloadPath == "" || downloadPath == null)
            {
                downloadPath = new KnownFolder(KnownFolderType.Downloads).Path;
            }
            bool response = true;
            try
            {
                byte[] result = new DownloadSubmissionRequest(orderId, submissionVersion, documentType).Download(Api.Client);
                FileStream fs = File.Create(downloadPath + "\\submission_" + orderId);
                fs.Write(result, 0, result.Length);
            }
            catch (Exception e)
            {
                response = false;
                Console.WriteLine("Downloading Error message: {0}", e.ToString());
            }

            return response;
        }

        public string VendorCancelOrder(string orderId, string message = "")
        {
            string response = null;
            var result = new CancelVendorOrderRequest(orderId, message).Execute(Api.Client);
            if (result.Status == 200)
            {
                response = result.Data;
            }
            return response;
        }

        public override void Save(VendorOrder entity)
        {
            throw new NotImplementedException();
        }
    }
}
