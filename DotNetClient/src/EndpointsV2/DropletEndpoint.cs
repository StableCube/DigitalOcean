using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace StableCube.DigitalOcean.DotNetClient
{
    public class DropletEndpoint : EndpointBase, IDropletEndpoint
    {
        public DropletEndpoint(HttpClient client) : base(client)
        {
        }

        public async Task<Droplet> GetAsync(
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

        public async Task<Droplet> GetByTagSingleOrDefaultAsync(
            string tag,
            CancellationToken cancellationToken = default(CancellationToken)
        )
        {
            var dropletResult = await GetByTagAsync(tag, cancellationToken);
            return dropletResult.Droplets.SingleOrDefault();
        }

        public async Task<DropletList> GetAllAsync(
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

        public async Task<DropletList> GetByTagAsync(
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

        public async Task<Droplet> CreateAsync(
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

        public async Task DeleteAsync(
            int dropletId,
            CancellationToken cancellationToken = default(CancellationToken)
        )
        {
            string endpoint = $"/v2/droplets/{dropletId}";

            var result = await _client.DeleteAsync(endpoint, cancellationToken);
            string jsonResult = await result.Content.ReadAsStringAsync();

            if(!result.IsSuccessStatusCode)
            {
                ApiErrorResult error = JsonConvert.DeserializeObject<ApiErrorResult>(jsonResult);
                throw new DigitalOceanApiCallException(error);
            }
        }

        public async Task DeleteByTagAsync(
            string tag,
            CancellationToken cancellationToken = default(CancellationToken)
        )
        {
            string endpoint = $"/v2/droplets?tag_name={tag}";

            var result = await _client.DeleteAsync(endpoint, cancellationToken);
            string jsonResult = await result.Content.ReadAsStringAsync();

            if(!result.IsSuccessStatusCode)
            {
                ApiErrorResult error = JsonConvert.DeserializeObject<ApiErrorResult>(jsonResult);
                throw new DigitalOceanApiCallException(error);
            }
        }
    }
}