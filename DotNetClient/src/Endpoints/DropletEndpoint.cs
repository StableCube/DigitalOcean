using System;
using System.Text;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace StableCube.DigitalOcean.DotNetClient
{
    public class DropletEndpoint : IDropletEndpoint
    {
        private HttpClient _client;

        public DropletEndpoint(
            HttpClient client
        )
        {
            _client = client;
        }

        private StringContent EncodeContent(object input)
        {
            return new StringContent(JsonConvert.SerializeObject(input, new JsonSerializerSettings()
                {
                    TypeNameHandling = TypeNameHandling.Auto
                }), Encoding.UTF8, "application/json");
        }

        public async Task<Droplet> GetDropletAsync(
            int dropletId,
            CancellationToken cancellationToken = default(CancellationToken)
        )
        {
            string endpoint = $"/v2/droplets/{dropletId}";

            var result = await _client.GetAsync(endpoint, cancellationToken);
            string jsonResult = await result.Content.ReadAsStringAsync();
            if(!result.IsSuccessStatusCode)
            {
                ApiErrorResult error = JsonConvert.DeserializeObject<ApiErrorResult>(jsonResult);
                throw new DigitalOceanApiCallException(error);
            }

            var resultObj = JsonConvert.DeserializeObject<DropletResult>(jsonResult);

            return resultObj.Droplet;
        }

        public async Task<DropletList> GetDropletsAsync(
            CancellationToken cancellationToken = default(CancellationToken)
        )
        {
            string endpoint = $"/v2/droplets";

            var result = await _client.GetAsync(endpoint, cancellationToken);
            string jsonResult = await result.Content.ReadAsStringAsync();
            if(!result.IsSuccessStatusCode)
            {
                ApiErrorResult error = JsonConvert.DeserializeObject<ApiErrorResult>(jsonResult);
                throw new DigitalOceanApiCallException(error);
            }

            var resultObj = JsonConvert.DeserializeObject<DropletList>(jsonResult);

            return resultObj;
        }

        public async Task<DropletList> GetDropletsByTagAsync(
            string tag,
            CancellationToken cancellationToken = default(CancellationToken)
        )
        {
            string endpoint = $"/v2/droplets?tag_name={tag}";

            var result = await _client.GetAsync(endpoint, cancellationToken);
            string jsonResult = await result.Content.ReadAsStringAsync();
            if(!result.IsSuccessStatusCode)
            {
                ApiErrorResult error = JsonConvert.DeserializeObject<ApiErrorResult>(jsonResult);
                throw new DigitalOceanApiCallException(error);
            }

            var resultObj = JsonConvert.DeserializeObject<DropletList>(jsonResult);

            return resultObj;
        }

        public async Task<Droplet> CreateDropletAsync(
            DropletCreate data,
            CancellationToken cancellationToken = default(CancellationToken)
        )
        {
            string endpoint = $"/v2/droplets";

            var result = await _client.PostAsync(endpoint, EncodeContent(data), cancellationToken);
            string jsonResult = await result.Content.ReadAsStringAsync();

            if(!result.IsSuccessStatusCode)
            {
                ApiErrorResult error = JsonConvert.DeserializeObject<ApiErrorResult>(jsonResult);
                throw new DigitalOceanApiCallException(error);
            }

            var resultObj = JsonConvert.DeserializeObject<Droplet>(jsonResult);

            return resultObj;
        }
    }
}