using RestSharp;

namespace Reggora.Api.Requests.Vendor.Evault
{
    class UploadDocumentRequest : ReggoraRequest
    {
        public UploadDocumentRequest(string evaultId, string filePath, string fileName) : base("vendor/evault/{evault_id}", Method.PUT)
        {

            AddParameter("evault_id", evaultId, ParameterType.UrlSegment);
            if (fileName != null || fileName != "")
            {
                AddParameter("file_name", fileName);
            }

            AddFile("file", filePath, MimeMapping.MimeUtility.GetMimeMapping(filePath));
        }
    }
}
