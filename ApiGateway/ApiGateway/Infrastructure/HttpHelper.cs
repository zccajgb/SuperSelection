namespace ApiGateway.Infrastructure
{
    using System;
    using System.Net.Http;
    using System.Net.Mime;
    using System.Text;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Serilog;

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
            using (var response = await this.httpClient.PostAsync(uri, content))
            {
                if (!response.IsSuccessStatusCode)
                {
                    Log.Logger.Error("request failed with error {@error}", response);
                    throw new HttpRequestException(response.StatusCode.ToString());
                }

                jsonContent = await response.Content.ReadAsStringAsync();
            }

            var result = JsonConvert.DeserializeObject<T>(jsonContent);
            return result;
        }

        public async Task<T> GetAsync<T>(string uri)
        {
            var jsonContent = string.Empty;
            using (var response = await this.httpClient.GetAsync(uri))
            {
                if (!response.IsSuccessStatusCode)
                {
                    Log.Logger.Error("request failed with error {@error}", response);
                    throw new HttpRequestException(response.StatusCode.ToString());
                }

                jsonContent = await response.Content.ReadAsStringAsync();
            }

            var result = JsonConvert.DeserializeObject<T>(jsonContent);
            return result;
        }
    }
}
