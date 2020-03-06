using System.Threading;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace StableCube.DigitalOcean.DotNetClient
{
    public class SizeEndpoint : EndpointBase, ISizeEndpoint
    {
        public SizeEndpoint(HttpClient client) : base(client)
        {
        }

        public async Task<Size[]> GetAllAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            string endpoint = $"/v2/sizes";

            var result = await _client.GetAsync(endpoint, cancellationToken);
            string jsonResult = await result.Content.ReadAsStringAsync();
            if(!result.IsSuccessStatusCode)
            {
                ApiErrorResult error = JsonConvert.DeserializeObject<ApiErrorResult>(jsonResult);
                throw new DigitalOceanApiCallException(error);
            }

            var resultObj = JsonConvert.DeserializeObject<SizeList>(jsonResult);

            return resultObj.Sizes;
        }
    }
}