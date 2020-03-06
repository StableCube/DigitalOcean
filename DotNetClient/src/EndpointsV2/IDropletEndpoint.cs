using System.Threading;
using System.Threading.Tasks;

namespace StableCube.DigitalOcean.DotNetClient
{
    public interface IDropletEndpoint
    {
        Task<Droplet> GetAsync(
            int dropletId,
            CancellationToken cancellationToken = default(CancellationToken)
        );

        Task<Droplet> GetByTagSingleOrDefaultAsync(
            string tag,
            CancellationToken cancellationToken = default(CancellationToken)
        );

        Task<DropletList> GetAllAsync(
            CancellationToken cancellationToken = default(CancellationToken)
        );

        Task<DropletList> GetByTagAsync(
            string tag,
            CancellationToken cancellationToken = default(CancellationToken)
        );

        Task<Droplet> CreateAsync(
            DropletCreate data,
            CancellationToken cancellationToken = default(CancellationToken)
        );

        Task DeleteAsync(
            int dropletId,
            CancellationToken cancellationToken = default(CancellationToken)
        );

        Task DeleteByTagAsync(
            string tag,
            CancellationToken cancellationToken = default(CancellationToken)
        );
    }
}