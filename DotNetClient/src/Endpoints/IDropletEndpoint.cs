using System.Threading;
using System.Threading.Tasks;

namespace StableCube.DigitalOcean.DotNetClient
{
    public interface IDropletEndpoint
    {
        Task<Droplet> GetDropletAsync(
            int dropletId,
            CancellationToken cancellationToken = default(CancellationToken)
        );

        Task<DropletList> GetDropletsAsync(
            CancellationToken cancellationToken = default(CancellationToken)
        );

        Task<DropletList> GetDropletsByTagAsync(
            string tag,
            CancellationToken cancellationToken = default(CancellationToken)
        );

        Task<Droplet> CreateDropletAsync(
            DropletCreate data,
            CancellationToken cancellationToken = default(CancellationToken)
        );
    }
}