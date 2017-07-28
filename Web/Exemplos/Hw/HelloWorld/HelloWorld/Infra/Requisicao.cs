using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Formatting;

namespace HelloWorld.Infra
{
    public static class Requisicao
    {
        private static readonly HttpClient _httpClient = new HttpClient();

        public static HttpResponseMessage Get(string uri)
        {
            return _httpClient.GetAsync(uri).Result;
        }

        public static HttpResponseMessage Delete(string uri)
        {
            return _httpClient.DeleteAsync(uri).Result;
        }

        public static HttpResponseMessage Post(string uri, object obj)
        {
            return _httpClient.PostAsync(uri, obj, JsonMediaTypeFormatter).Result;
        }

        public static HttpResponseMessage Put(string uri, object obj)
        {
            return _httpClient.PutAsync(uri, obj, JsonMediaTypeFormatter).Result;
        }

        private static readonly JsonMediaTypeFormatter JsonMediaTypeFormatter
            = new JsonMediaTypeFormatter
            {
                SerializerSettings = new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    NullValueHandling = NullValueHandling.Include
                }
            };
    }
}