using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SupportLib.Web
{
    public class HttpResponse<TResponse>
    {
        public TResponse Value { get; private set; }

        public HttpStatusCode StatusCode { get; private set; }

        public bool IsSuccess { get; private set; }

        public string Message { get; private set; }

        public Uri RequestUri { get; private set; }

        public Uri ResponseUri { get; private set; }

        public static HttpResponse<TResponse> Success(HttpStatusCode httpStatusCode, TResponse value,
                                                      Uri requestUri = null, Uri responseUri = null) => new()
                                                      {
                                                          Value = value,
                                                          IsSuccess = true,
                                                          StatusCode = httpStatusCode,
                                                          RequestUri = requestUri,
                                                          ResponseUri = responseUri,
                                                      };

        public static HttpResponse<TResponse> Fail(HttpStatusCode httpStatusCode, TResponse value,
                                                   Uri requestUri = null, Uri responseUri = null) => new()
                                                   {
                                                       Value = value,
                                                       StatusCode = httpStatusCode,
                                                       RequestUri = requestUri,
                                                       ResponseUri = responseUri,
                                                   };
    }
}
