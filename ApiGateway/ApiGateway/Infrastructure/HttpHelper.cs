using ApiGateway.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ApiGateway.Infrastructure
{
    public class HttpHelper
    {
        private readonly HttpClient httpClient;

        public HttpHelper(IHttpClientFactory httpClientFactory)
        {
            this.httpClient = httpClientFactory.CreateClient();
        }

        public async Task<T> PostAsync<T>(string uri, object payload)
        {
            var json = JsonConvert.SerializeObject(payload);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var jsonContent = string.Empty;
            using (var response = await httpClient.PostAsync(uri, content))
            {
                if (!response.IsSuccessStatusCode) throw new HttpRequestException(response.StatusCode.ToString());
                jsonContent = await response.Content.ReadAsStringAsync();
            }

            var result = JsonConvert.DeserializeObject<T>(jsonContent);
            return result;
        }

        public async Task<object> GetAsync(string uri)
        {
            var jsonContent = String.Empty;
            using (var response = await httpClient.GetAsync(uri))
            {
                if (!response.IsSuccessStatusCode) throw new HttpRequestException(response.StatusCode.ToString());
                jsonContent = await response.Content.ReadAsStringAsync();
            }
            var result = JsonConvert.DeserializeObject(jsonContent);
            return result;
        }
    }
}
