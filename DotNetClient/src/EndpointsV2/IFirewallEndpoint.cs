using System.Threading;
using System.Threading.Tasks;

namespace StableCube.DigitalOcean.DotNetClient
{
    public interface IFirewallEndpoint
    {
        Task<Firewall> GetAsync(
            string firewallId,
            CancellationToken cancellationToken = default(CancellationToken)
        );

        Task<Firewall> GetByNameAsync(
            string firewallName,
            CancellationToken cancellationToken = default(CancellationToken)
        );

        Task<Firewall[]> GetAllAsync(
            CancellationToken cancellationToken = default(CancellationToken)
        );

        Task<Firewall> CreateAsync(
            FirewallCreate data,
            CancellationToken cancellationToken = default(CancellationToken)
        );

        Task DeleteAsync(
            string firewallId,
            CancellationToken cancellationToken = default(CancellationToken)
        );

        Task<Firewall> AddDropletsAsync(
            string firewallId,
            int[] dropletIds,
            CancellationToken cancellationToken = default(CancellationToken)
        );

        Task RemoveDropletsAsync(
            string firewallId,
            int[] dropletIds,
            CancellationToken cancellationToken = default(CancellationToken)
        );
    }
}