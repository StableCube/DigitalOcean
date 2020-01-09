using System;
using System.Text;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace StableCube.DigitalOcean.DotNetClient
{
    public class KubernetesEndpoint : IKubernetesEndpoint
    {
        private HttpClient _client;

        public KubernetesEndpoint(
            HttpClient client
        )
        {
            _client = client;
        }

        /// <summary>
        /// Returns cluster config in yaml format
        /// </summary>
        /// <param name="clusterId"></param>
        /// <returns></returns>
        public async Task<HttpContent> GetKubeConfigAsync(
            string clusterId,
            CancellationToken cancellationToken = default(CancellationToken)
        )
        {
            string endpoint = $"/v2/kubernetes/clusters/{clusterId}/kubeconfig";

            var result = await _client.GetAsync(endpoint, cancellationToken);
            result.EnsureSuccessStatusCode();

            return result.Content;
        }

        public async Task<NodePool[]> ListNodePoolsAsync(
            string clusterId,
            CancellationToken cancellationToken = default(CancellationToken)
        )
        {
            string endpoint = $"/v2/kubernetes/clusters/{clusterId}/node_pools";

            var result = await _client.GetAsync(endpoint, cancellationToken);
            string jsonResult = await result.Content.ReadAsStringAsync();

            if(!result.IsSuccessStatusCode)
            {
                ApiErrorResult error = JsonConvert.DeserializeObject<ApiErrorResult>(jsonResult);
                throw new DigitalOceanApiCallException(error);
            }

            return JsonConvert.DeserializeObject<NodePoolListResult>(jsonResult).NodePools;
        }

        public async Task<NodePool> GetNodePoolAsync(
            string clusterId, 
            string nodePoolId,
            CancellationToken cancellationToken = default(CancellationToken)
        )
        {
            string endpoint = $"/v2/kubernetes/clusters/{clusterId}/node_pools/{nodePoolId}";

            var result = await _client.GetAsync(endpoint, cancellationToken);
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
            List<string> tags = null,
            CancellationToken cancellationToken = default(CancellationToken)
        )
        {
            string endpoint = $"/v2/kubernetes/clusters/{clusterId}/node_pools";

            var data = new CreateNodePoolInput()
            {
                Size = doDropletSize,
                Name = poolName,
                Count = nodeCount
            };

            if(tags != null)
                data.Tags = tags;

            var result = await _client.PostAsync(endpoint, EncodeContent(data), cancellationToken);

            string jsonResult = await result.Content.ReadAsStringAsync();

            if(!result.IsSuccessStatusCode)
            {
                ApiErrorResult error = JsonConvert.DeserializeObject<ApiErrorResult>(jsonResult);
                throw new DigitalOceanApiCallException(error);
            }

            var nodePool = JsonConvert.DeserializeObject<NodePoolResult>(jsonResult).NodePool;

            return nodePool;
        }

        public async Task<NodePool> UpdateNodePoolAsync(
            string clusterId,
            string nodePoolId,
            string poolName, 
            int nodeCount, 
            List<string> tags = null,
            CancellationToken cancellationToken = default(CancellationToken)
        )
        {
            string endpoint = $"/v2/kubernetes/clusters/{clusterId}/node_pools/{nodePoolId}";

            var data = new UpdateNodePoolInput()
            {
                Name = poolName,
                Count = nodeCount
            };

            if(tags != null)
                data.Tags = tags;

            var result = await _client.PutAsync(endpoint, EncodeContent(data), cancellationToken);

            string jsonResult = await result.Content.ReadAsStringAsync();

            if(!result.IsSuccessStatusCode)
            {
                ApiErrorResult error = JsonConvert.DeserializeObject<ApiErrorResult>(jsonResult);
                throw new DigitalOceanApiCallException(error);
            }

            var nodePool = JsonConvert.DeserializeObject<NodePoolResult>(jsonResult).NodePool;

            return nodePool;
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
            string nodeId,
            CancellationToken cancellationToken = default(CancellationToken)
        )
        {
            string endpoint = $"/v2/kubernetes/clusters/{clusterId}/node_pools/{nodePoolId}/nodes/{nodeId}";

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