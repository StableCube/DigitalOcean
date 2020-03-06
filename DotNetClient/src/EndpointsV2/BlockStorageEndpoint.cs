using System.Threading;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace StableCube.DigitalOcean.DotNetClient
{
    public class BlockStorageEndpoint : EndpointBase, IBlockStorageEndpoint
    {
        public BlockStorageEndpoint(HttpClient client) : base(client)
        {
        }

        public async Task<Volume> CreateVolumeAsync(
            BlockStorageVolCreate data,
            CancellationToken cancellationToken = default(CancellationToken)
        )
        {
            string endpoint = $"/v2/volumes";

            var result = await _client.PostAsync(endpoint, EncodeContent(data), cancellationToken);
            string jsonResult = await result.Content.ReadAsStringAsync();

            if(!result.IsSuccessStatusCode)
            {
                ApiErrorResult error = JsonConvert.DeserializeObject<ApiErrorResult>(jsonResult);
                throw new DigitalOceanApiCallException(error);
            }

            var resultObj = JsonConvert.DeserializeObject<Volume>(jsonResult);

            return resultObj;
        }

        public async Task<Volume> GetVolumeAsync(
            string volumeId,
            CancellationToken cancellationToken = default(CancellationToken)
        )
        {
            string endpoint = $"/v2/volumes/{volumeId}";

            var result = await _client.GetAsync(endpoint, cancellationToken);
            string jsonResult = await result.Content.ReadAsStringAsync();
            if(!result.IsSuccessStatusCode)
            {
                ApiErrorResult error = JsonConvert.DeserializeObject<ApiErrorResult>(jsonResult);
                throw new DigitalOceanApiCallException(error);
            }

            var resultObj = JsonConvert.DeserializeObject<VolumeResult>(jsonResult);

            return resultObj.Volume;
        }

        public async Task<Volume> GetVolumeByNameAsync(
            string volumeName,
            string region = null,
            CancellationToken cancellationToken = default(CancellationToken)
        )
        {
            var vols = await GetAllVolumesByNameAsync(volumeName, region, cancellationToken);
            return vols.SingleOrDefault();
        }

        public async Task<Volume[]> GetAllVolumesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            string endpoint = $"/v2/volumes";

            var result = await _client.GetAsync(endpoint, cancellationToken);
            string jsonResult = await result.Content.ReadAsStringAsync();
            if(!result.IsSuccessStatusCode)
            {
                ApiErrorResult error = JsonConvert.DeserializeObject<ApiErrorResult>(jsonResult);
                throw new DigitalOceanApiCallException(error);
            }

            var resultObj = JsonConvert.DeserializeObject<VolumeList>(jsonResult);

            return resultObj.Volumes;
        }

        public async Task<Volume[]> GetAllVolumesByNameAsync(
            string volumeName,
            string region = null,
            CancellationToken cancellationToken = default(CancellationToken)
        )
        {
            string endpoint = $"/v2/volumes?name={volumeName}";
            if(region != null)
                endpoint += $"&region={region}";
            
            var result = await _client.GetAsync(endpoint, cancellationToken);
            string jsonResult = await result.Content.ReadAsStringAsync();
            if(!result.IsSuccessStatusCode)
            {
                ApiErrorResult error = JsonConvert.DeserializeObject<ApiErrorResult>(jsonResult);
                throw new DigitalOceanApiCallException(error);
            }

            var resultObj = JsonConvert.DeserializeObject<VolumeList>(jsonResult);

            return resultObj.Volumes;
        }

        public async Task DeleteVolumeAsync(
            string volumeId,
            CancellationToken cancellationToken = default(CancellationToken)
        )
        {
            string endpoint = $"/v2/volumes/{volumeId}";

            var result = await _client.DeleteAsync(endpoint, cancellationToken);
            string jsonResult = await result.Content.ReadAsStringAsync();
            if(!result.IsSuccessStatusCode)
            {
                ApiErrorResult error = JsonConvert.DeserializeObject<ApiErrorResult>(jsonResult);
                throw new DigitalOceanApiCallException(error);
            }
        }

        public async Task DeleteVolumeByNameAsync(
            string volumeName,
            string region = null,
            CancellationToken cancellationToken = default(CancellationToken)
        )
        {
            string endpoint = $"/v2/volumes?name={volumeName}";
            if(region != null)
                endpoint += $"&region={region}";

            var result = await _client.DeleteAsync(endpoint, cancellationToken);
            string jsonResult = await result.Content.ReadAsStringAsync();
            if(!result.IsSuccessStatusCode)
            {
                ApiErrorResult error = JsonConvert.DeserializeObject<ApiErrorResult>(jsonResult);
                throw new DigitalOceanApiCallException(error);
            }
        }

        public async Task<DigitalOceanAction> AttachVolumeAsync(
            string volumeId,
            VolumeAttach data,
            CancellationToken cancellationToken = default(CancellationToken)
        )
        {
            string endpoint = $"/v2/volumes/{volumeId}/actions";

            var result = await _client.PostAsync(endpoint, EncodeContent(data), cancellationToken);
            string jsonResult = await result.Content.ReadAsStringAsync();
            if(!result.IsSuccessStatusCode)
            {
                ApiErrorResult error = JsonConvert.DeserializeObject<ApiErrorResult>(jsonResult);
                throw new DigitalOceanApiCallException(error);
            }

            var resultObj = JsonConvert.DeserializeObject<DigitalOceanActionResult>(jsonResult);

            return resultObj.Action;
        }

        public async Task<DigitalOceanAction> DetachVolumeAsync(
            string volumeId,
            VolumeDetach data,
            CancellationToken cancellationToken = default(CancellationToken)
        )
        {
            string endpoint = $"/v2/volumes/{volumeId}/actions";

            var result = await _client.PostAsync(endpoint, EncodeContent(data), cancellationToken);
            string jsonResult = await result.Content.ReadAsStringAsync();
            if(!result.IsSuccessStatusCode)
            {
                ApiErrorResult error = JsonConvert.DeserializeObject<ApiErrorResult>(jsonResult);
                throw new DigitalOceanApiCallException(error);
            }

            var resultObj = JsonConvert.DeserializeObject<DigitalOceanActionResult>(jsonResult);

            return resultObj.Action;
        }
    }
}