using Reggora.Api.Entity;
using Reggora.Api.Requests.Vendor.Evault;
using Reggora.Api.Util;
using Syroot.Windows.IO;
using System;
using System.IO;

namespace Reggora.Api.Storage.Vendor
{
    public class EvaultManagementStorage : Storage<VendorEvault, Api.Vendor>
    {
        public EvaultManagementStorage(Api.Vendor api) : base(api)
        {
        }

        public override VendorEvault Get(string id)
        {
            Known.TryGetValue(id, out var returned);

            if (returned == null)
            {
                var result = new GetEvaultRequest(id).Execute(Api.Client);
                if (result.Status == 200)
                {
                    returned = new VendorEvault();
                    returned.UpdateFromRequest(Utils.DictionaryOfJsonFields(result.Data));
                    Known.Add(returned.Id, returned);
                }
            }

            return returned;
        }

        public bool GetDocument(string evaultId, string documentId, string downloadPath)
        {
            if (downloadPath == "" || downloadPath == null)
            {
                downloadPath = new KnownFolder(KnownFolderType.Downloads).Path;
            }
            bool response = true;
            try
            {
                byte[] result = new GetDocumentRequest(evaultId, documentId).Download(Api.Client);
                FileStream fs = File.Create(downloadPath + "\\evault_" + evaultId);
                fs.Write(result, 0, result.Length);
            }
            catch (Exception e)
            {
                response = false;
                Console.WriteLine("Downloading Error message: {0}", e.ToString());
            }

            return response;
        }

        public string UploadDocument(string evaultId, string filePath, string fileName = null)
        {
            string response = null;
            var result = new UploadDocumentRequest(evaultId, filePath, fileName).Execute(Api.Client);
            if (result.Status == 200)
            {
                response = result.Data;

            }

            return response;
        }

        public string DeleteDocument(string evaultId, string documentId)
        {
            string response = "";
            var result = new DeleteDocumentRequest(evaultId, documentId).Execute(Api.Client);
            if (result.Status == 200)
            {
                response = result.Data;
            }
            return response;
        }

        public override void Save(VendorEvault entity)
        {
            throw new NotImplementedException();
        }
    }
}
