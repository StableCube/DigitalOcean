using System.Threading;
using System.Threading.Tasks;
using System.Net.Http;
using System.Collections.Generic;

namespace StableCube.DigitalOcean.DotNetClient
{
    public interface IKubernetesClient
    {
        Task<HttpContent> GetKubeConfigAsync(
            string clusterId,
            CancellationToken cancellationToken = default(CancellationToken)
        );

        Task<NodePool[]> ListNodePoolsAsync(
            string clusterId,
            CancellationToken cancellationToken = default(CancellationToken)
        );

        Task<NodePool> GetNodePoolAsync(
            string clusterId, 
            string nodePoolId,
            CancellationToken cancellationToken = default(CancellationToken)
        );

        Task<NodePool> CreateNodePoolAsync(
            string clusterId, 
            string doDropletSize, 
            string poolName, 
            int nodeCount, 
            List<string> tags = null,
            CancellationToken cancellationToken = default(CancellationToken)
        );

        Task<NodePool> UpdateNodePoolAsync(
            string clusterId,
            string nodePoolId,
            string poolName, 
            int nodeCount, 
            List<string> tags = null,
            CancellationToken cancellationToken = default(CancellationToken)
        );

        Task DeleteNodeAsync(
            string clusterId,
            string nodePoolId,
            string nodeId,
            CancellationToken cancellationToken = default(CancellationToken)
        );
    }
}