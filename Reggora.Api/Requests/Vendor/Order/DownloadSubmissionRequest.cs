using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Reggora.Api.Util;
using RestSharp;

namespace Reggora.Api.Requests.Vendor.Order
{
    public class DownloadSubmissionRequest : ReggoraRequest
    {
        public DownloadSubmissionRequest(string orderId, uint submissionVersion, string documentType) : base(
            "vendor/submission/{order_id}/{submission_version}/{document_type}", Method.GET)
        {
            AddParameter("order_id", orderId, ParameterType.UrlSegment);
            AddParameter("submission_version", submissionVersion, ParameterType.UrlSegment);
            AddParameter("document_type", documentType, ParameterType.UrlSegment);
        }
        public new Response Execute(IRestClient client)
        {
            return Execute<Response>(client);
        }
        public byte[] Download(IRestClient client)
        {
            return client.DownloadData(this, true);
        }
        public class Response
        {
            [JsonProperty("error")]
            public string Error { get; set; }
        }
    }
}