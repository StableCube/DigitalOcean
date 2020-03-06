using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace StableCube.DigitalOcean.DotNetClient
{
    public class FirewallEndpoint : EndpointBase, IFirewallEndpoint
    {
        public FirewallEndpoint(HttpClient client) : base(client)
        {
        }

        public async Task<Firewall> GetAsync(
            string firewallId,
            CancellationToken cancellationToken = default(CancellationToken)
        )
        {
            string endpoint = $"/v2/firewalls/{firewallId}";

            var result = await _client.GetAsync(endpoint, cancellationToken);
            string jsonResult = await result.Content.ReadAsStringAsync();
            if(!result.IsSuccessStatusCode)
            {
                ApiErrorResult error = JsonConvert.DeserializeObject<ApiErrorResult>(jsonResult);
                throw new DigitalOceanApiCallException(error);
            }

            var resultObj = JsonConvert.DeserializeObject<FirewallResult>(jsonResult);

            return resultObj.Firewall;
        }

        public async Task<Firewall[]> GetAllAsync(
            CancellationToken cancellationToken = default(CancellationToken)
        )
        {
            string endpoint = $"/v2/firewalls";

            var result = await _client.GetAsync(endpoint, cancellationToken);
            string jsonResult = await result.Content.ReadAsStringAsync();
            if(!result.IsSuccessStatusCode)
            {
                ApiErrorResult error = JsonConvert.DeserializeObject<ApiErrorResult>(jsonResult);
                throw new DigitalOceanApiCallException(error);
            }

            var resultObj = JsonConvert.DeserializeObject<FirewallList>(jsonResult);

            return resultObj.Firewalls;
        }

        public async Task<Firewall> GetByNameAsync(
            string firewallName,
            CancellationToken cancellationToken = default(CancellationToken)
        )
        {
            var firewalls = await GetAllAsync(cancellationToken);
            foreach (var firewall in firewalls)
            {
                if(firewall.Name == firewallName)
                {
                    return firewall;
                }
            }

            return null;
        }

        public async Task<Firewall> CreateAsync(
            FirewallCreate data,
            CancellationToken cancellationToken = default(CancellationToken)
        )
        {
            string endpoint = $"/v2/firewalls";

            var result = await _client.PostAsync(endpoint, EncodeContent(data), cancellationToken);
            string jsonResult = await result.Content.ReadAsStringAsync();
            if(!result.IsSuccessStatusCode)
            {
                ApiErrorResult error = JsonConvert.DeserializeObject<ApiErrorResult>(jsonResult);
                throw new DigitalOceanApiCallException(error);
            }

            var resultObj = JsonConvert.DeserializeObject<Firewall>(jsonResult);

            return resultObj;
        }

        public async Task DeleteAsync(
            string firewallId,
            CancellationToken cancellationToken = default(CancellationToken)
        )
        {
            string endpoint = $"/v2/firewalls/{firewallId}";

            var result = await _client.DeleteAsync(endpoint, cancellationToken);
            string jsonResult = await result.Content.ReadAsStringAsync();
            if(!result.IsSuccessStatusCode)
            {
                ApiErrorResult error = JsonConvert.DeserializeObject<ApiErrorResult>(jsonResult);
                throw new DigitalOceanApiCallException(error);
            }
        }

        public async Task<Firewall> AddDropletsAsync(
            string firewallId,
            int[] dropletIds,
            CancellationToken cancellationToken = default(CancellationToken)
        )
        {
            string endpoint = $"/v2/firewalls/{firewallId}/droplets";
            var data = new {
                droplet_ids = dropletIds
            };

            var result = await _client.PostAsync(endpoint, EncodeContent(data), cancellationToken);
            string jsonResult = await result.Content.ReadAsStringAsync();
            if(!result.IsSuccessStatusCode)
            {
                ApiErrorResult error = JsonConvert.DeserializeObject<ApiErrorResult>(jsonResult);
                throw new DigitalOceanApiCallException(error);
            }

            var resultObj = JsonConvert.DeserializeObject<Firewall>(jsonResult);

            return resultObj;
        }

        public async Task RemoveDropletsAsync(
            string firewallId,
            int[] dropletIds,
            CancellationToken cancellationToken = default(CancellationToken)
        )
        {
            string endpoint = $"/v2/firewalls/{firewallId}/droplets";
            var data = new {
                droplet_ids = dropletIds
            };

            //We have to get funky to send a body in a delete
            var uri = new Uri(UriUtility.Combine(_client.BaseAddress.ToString(), endpoint));
            HttpRequestMessage request = new HttpRequestMessage
            {
                Content = EncodeContent(data),
                Method = HttpMethod.Delete,
                RequestUri = uri
            };

            var result = await _client.SendAsync(request, cancellationToken);
            string jsonResult = await result.Content.ReadAsStringAsync();
            if(!result.IsSuccessStatusCode)
            {
                ApiErrorResult error = JsonConvert.DeserializeObject<ApiErrorResult>(jsonResult);
                throw new DigitalOceanApiCallException(error);
            }
        }
    }
}