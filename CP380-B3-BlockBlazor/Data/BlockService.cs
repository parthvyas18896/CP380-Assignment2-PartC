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
    public class BlockService
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
        public BlockService(IHttpClientFactory httpClientFactory,IConfiguration configuration)
        {
            _httpclient = httpClientFactory.CreateClient();
            _config = configuration.GetSection("BlockService");
        }
        //
        // TODO: Add an async method that returns an IEnumerable<Block> (list of Blocks)
        //       from the web service
        //
        public async Task<IEnumerable<Block>> GetBlocksAsync()
        {
            var response = await _httpclient.GetAsync(_config["blockurl"]);
            if (response.IsSuccessStatusCode)
            {
                JsonSerializerOptions options = new(JsonSerializerDefaults.Web);
                return await JsonSerializer.DeserializeAsync<IEnumerable<Block>>(
                    await response.Content.ReadAsStreamAsync(), options
                    
                    );
                //return await
            }
            return Array.Empty<Block>();
        }


    }
}

