using System;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace StableCube.DigitalOcean.DotNetClient
{
    public class KubernetesClient : IKubernetesClient
    {
        private HttpClient _client;
        private ClientOptions _options;

        public KubernetesClient(
            HttpClient client,
            ClientOptions options
        )
        {
            _client = client;
            _options = options;
        }

        /// <summary>
        /// Returns cluster config in yaml format
        /// </summary>
        /// <param name="clusterId"></param>
        /// <returns></returns>
        public async Task<HttpContent> GetKubeConfigAsync(string clusterId)
        {
            string endpoint = $"/v2/kubernetes/clusters/{clusterId}/kubeconfig";

            var result = await _client.GetAsync(endpoint);
            result.EnsureSuccessStatusCode();

            return result.Content;
        }

        public async Task<NodePool[]> ListNodePoolsAsync(string clusterId)
        {
            string endpoint = $"/v2/kubernetes/clusters/{clusterId}/node_pools";

            var result = await _client.GetAsync(endpoint);
            string jsonResult = await result.Content.ReadAsStringAsync();

            if(!result.IsSuccessStatusCode)
            {
                ApiErrorResult error = JsonConvert.DeserializeObject<ApiErrorResult>(jsonResult);
                throw new DigitalOceanApiCallException(error);
            }

            return JsonConvert.DeserializeObject<NodePoolListResult>(jsonResult).NodePools;
        }

        public async Task<NodePool> GetNodePoolAsync(string clusterId, string nodePoolId)
        {
            string endpoint = $"/v2/kubernetes/clusters/{clusterId}/node_pools/{nodePoolId}";

            var result = await _client.GetAsync(endpoint);
            string jsonResult = await result.Content.ReadAsStringAsync();

            if(!result.IsSuccessStatusCode)
            {
                ApiErrorResult error = JsonConvert.DeserializeObject<ApiErrorResult>(jsonResult);
                throw new DigitalOceanApiCallException(error);
            }

            return JsonConvert.DeserializeObject<NodePoolResult>(jsonResult).NodePool;
        }

        /// <summary>
        /// To add an additional node pool to a Kubernetes clusters, send a 
        /// POST request to /v2/kubernetes/clusters/$K8S_CLUSTER_ID/node_pools with the following attributes.
        /// </summary>
        /// <param name="clusterId"></param>
        /// <param name="doDropletSize">The slug identifier for the type of Droplet to be used as workers in the node pool.</param>
        /// <param name="poolName">A human-readable name for the node pool.</param>
        /// <param name="nodeCount">The number of Droplet instances in the node pool.</param>
        /// <param name="tags">A flat array of tag names as strings to be applied to the node pool. All node pools will be 
        /// automatically tagged "k8s," "k8s-worker," and "k8s:$K8S_CLUSTER_ID" in addition to any tags provided by the user.</param>
        /// <returns></returns>
        public async Task<NodePool> CreateNodePoolAsync(
            string clusterId, 
            string doDropletSize, 
            string poolName, 
            int nodeCount, 
            List<string> tags)
        {
            string endpoint = $"/v2/kubernetes/clusters/{clusterId}/node_pools";

            var result = await _client.PostAsync(endpoint, EncodeContent(new CreateNodePoolInput()
            {
                Size = doDropletSize,
                Name = poolName,
                Count = nodeCount,
                Tags = tags
            }));

            string jsonResult = await result.Content.ReadAsStringAsync();

            if(!result.IsSuccessStatusCode)
            {
                ApiErrorResult error = JsonConvert.DeserializeObject<ApiErrorResult>(jsonResult);
                throw new DigitalOceanApiCallException(error);
            }

            return JsonConvert.DeserializeObject<NodePoolResult>(jsonResult).NodePool;
        }

        public async Task<NodePool> UpdateNodePoolAsync(
            string clusterId,
            string nodePoolId,
            string poolName, 
            int nodeCount, 
            List<string> tags)
        {
            string endpoint = $"/v2/kubernetes/clusters/{clusterId}/node_pools/{nodePoolId}";

            var result = await _client.PutAsync(endpoint, EncodeContent(new UpdateNodePoolInput()
            {
                Name = poolName,
                Count = nodeCount,
                Tags = tags
            }));

            string jsonResult = await result.Content.ReadAsStringAsync();

            if(!result.IsSuccessStatusCode)
            {
                ApiErrorResult error = JsonConvert.DeserializeObject<ApiErrorResult>(jsonResult);
                throw new DigitalOceanApiCallException(error);
            }

            return JsonConvert.DeserializeObject<NodePoolResult>(jsonResult).NodePool;
        }

        private StringContent EncodeContent(object input)
        {
            return new StringContent(JsonConvert.SerializeObject(input, new JsonSerializerSettings()
                {
                    TypeNameHandling = TypeNameHandling.Auto
                }), Encoding.UTF8, "application/json");
        }

        public async Task DeleteNodeAsync(
            string clusterId,
            string nodePoolId,
            string nodeId
        )
        {
            string endpoint = $"/v2/kubernetes/clusters/{clusterId}/node_pools/{nodePoolId}/nodes/{nodeId}";

            var result = await _client.DeleteAsync(endpoint);

            string jsonResult = await result.Content.ReadAsStringAsync();

            if(!result.IsSuccessStatusCode)
            {
                ApiErrorResult error = JsonConvert.DeserializeObject<ApiErrorResult>(jsonResult);
                throw new DigitalOceanApiCallException(error);
            }
        }
    }
}