using System.Threading;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace StableCube.DigitalOcean.DotNetClient
{
    public class ImageEndpoint : EndpointBase, IImageEndpoint
    {
        public ImageEndpoint(HttpClient client) : base(client)
        {
        }

        public async Task<Image[]> GetAllAsync(
            CancellationToken cancellationToken = default(CancellationToken)
        )
        {
            string endpoint = $"/v2/images";

            var result = await _client.GetAsync(endpoint, cancellationToken);
            string jsonResult = await result.Content.ReadAsStringAsync();
            if(!result.IsSuccessStatusCode)
            {
                ApiErrorResult error = JsonConvert.DeserializeObject<ApiErrorResult>(jsonResult);
                throw new DigitalOceanApiCallException(error);
            }

            var resultObj = JsonConvert.DeserializeObject<ImageList>(jsonResult);

            return resultObj.Images;
        }

        public async Task<Image[]> GetAllDistributionImagesAsync(
            CancellationToken cancellationToken = default(CancellationToken)
        )
        {
            string endpoint = $"/v2/images?type=distribution";

            var result = await _client.GetAsync(endpoint, cancellationToken);
            string jsonResult = await result.Content.ReadAsStringAsync();
            if(!result.IsSuccessStatusCode)
            {
                ApiErrorResult error = JsonConvert.DeserializeObject<ApiErrorResult>(jsonResult);
                throw new DigitalOceanApiCallException(error);
            }

            var resultObj = JsonConvert.DeserializeObject<ImageList>(jsonResult);

            return resultObj.Images;
        }
    }
}