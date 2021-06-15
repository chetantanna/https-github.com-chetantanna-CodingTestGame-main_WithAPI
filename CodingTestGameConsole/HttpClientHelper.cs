using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace CodingTestGameConsole
{
    public static class HttpClientHelper
    {
        public static HttpClient GetHttpClient(string BaseUrl)
        {
            //single setup of client handler
            HttpClientHandler handler = new HttpClientHandler();
            var client = new HttpClient(handler, false);
            client.BaseAddress = new Uri(BaseUrl);
            return client;

        }
        public static HttpClient GetHttpClientPost(string BaseUrl)
        {
            //single setup of client handler
            HttpClientHandler handler = new HttpClientHandler();
            var client = new HttpClient(handler,false);
            client.BaseAddress = new Uri(BaseUrl);
            return client;

        }
    }
}
