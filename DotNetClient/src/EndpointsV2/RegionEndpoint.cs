using System.Threading;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace StableCube.DigitalOcean.DotNetClient
{
    public class RegionEndpoint : EndpointBase, IRegionEndpoint
    {
        public RegionEndpoint(HttpClient client) : base(client)
        {
        }

        public async Task<Region[]> GetAllAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            string endpoint = $"/v2/regions";

            var result = await _client.GetAsync(endpoint, cancellationToken);
            string jsonResult = await result.Content.ReadAsStringAsync();
            if(!result.IsSuccessStatusCode)
            {
                ApiErrorResult error = JsonConvert.DeserializeObject<ApiErrorResult>(jsonResult);
                throw new DigitalOceanApiCallException(error);
            }

            var resultObj = JsonConvert.DeserializeObject<RegionList>(jsonResult);

            return resultObj.Regions;
        }
    }
}