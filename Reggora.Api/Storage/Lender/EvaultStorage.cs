using Reggora.Api.Entity;
using Reggora.Api.Requests.Lender.Evaults;
using Reggora.Api.Util;
using System;
using System.Collections.Generic;

namespace Reggora.Api.Storage.Lender
{
    public class EvaultStorage : Storage<Evault, Api.Lender>
    {
        public EvaultStorage(Api.Lender api) : base(api)
        {
        }

        public override Evault Get(string id)
        {
            Known.TryGetValue(id, out var returned);

            if (returned == null)
            {
                var result = new GetEvaultRequest(id).Execute(Api.Client);
                if (result.Status == 200)
                {
                    returned = new Evault();
                    returned.UpdateFromRequest(Utils.DictionaryOfJsonFields(result.Data.Evault));
                    Known.Add(returned.Id, returned);
                }
            }

            return returned;
        }

        public void GetDocument(string evaultId, string documentId)
        {
            new GetDocumentRequest(evaultId, documentId).Execute(Api.Client);
        }

        public string UploadDocument(string evaultId, string filePath)
        {
            string response = null;
            var result = new UploadDocumentRequest(evaultId, filePath).Execute(Api.Client);
            if (result.Status == 200)
            {
                response = result.Data;

            }

            return response;
        }


        public string UploadPS(string orderId, string filePath, string documentName = null)
        {
            string response = null;
            var result = new UploadPSRequest(orderId, filePath, documentName).Execute(Api.Client);
            if (result.Status == 200)
            {
                response = result.Data;

            }
            return response;
        }

        public string DeleteDocument(string evaultId, string documentId)
        {
            string response = null;
            var result = new DeleteDocumentRequest(evaultId, documentId).Execute(Api.Client);
            if (result.Status == 200)
            {
                response = result.Data;

            }

            return response;
        }


        public override void Save(Evault entity)
        {
            throw new NotImplementedException();
        }
    }
}
