using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using CP380_B1_BlockList.Models;


namespace CP380_B3_BlockBlazor.Data
{
    public class PendingTransactionService
    {
        // TODO: Add variables for the dependency-injected resources
        //       - httpClient
        //       - configuration
        //
        static HttpClient _httpclient;
        private readonly IConfiguration _config;
        //
        // TODO: Add a constructor with IConfiguration and IHttpClientFactory arguments
        //
        public PendingTransactionService(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpclient = httpClientFactory.CreateClient();
            _config = configuration.GetSection("PendingTransactionService");
        }

        //
        // TODO: Add an async method that returns an IEnumerable<Payload> (list of Payloads)
        //       from the web service
        //
        public async Task<IEnumerable<PendingTransactionService>> GetBlocks()
        {
            var response = await _httpclient.GetAsync(_config["blockurl"]);
            if (response.IsSuccessStatusCode)
            {
                JsonSerializerOptions options = new(JsonSerializerDefaults.Web);
                return await JsonSerializer.DeserializeAsync<IEnumerable<PendingTransactionService>>(
                    await response.Content.ReadAsStreamAsync(), options

                    );
                //return await
            }
            return Array.Empty<PendingTransactionService>();
        }
        //
        // TODO: Add an async method that returns an HttpResponseMessage
        //       and accepts a Payload object.
        //       This method should POST the Payload to the web API server
        //
    }
}
