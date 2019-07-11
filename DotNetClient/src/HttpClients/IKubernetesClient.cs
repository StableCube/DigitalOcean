using System.Threading.Tasks;
using System.Net.Http;
using System.Collections.Generic;

namespace StableCube.DigitalOcean.DotNetClient
{
    public interface IKubernetesClient
    {
        Task<HttpContent> GetKubeConfigAsync(string clusterId);

        Task<NodePool[]> ListNodePoolsAsync(string clusterId);

        Task<NodePool> GetNodePoolAsync(string clusterId, string nodePoolId);

        Task<NodePool> CreateNodePoolAsync(
            string clusterId, 
            string doDropletSize, 
            string poolName, 
            int nodeCount, 
            List<string> tags = null);

        Task<NodePool> UpdateNodePoolAsync(
            string clusterId,
            string nodePoolId,
            string poolName, 
            int nodeCount, 
            List<string> tags = null);

        Task DeleteNodeAsync(
            string clusterId,
            string nodePoolId,
            string nodeId);
    }
}