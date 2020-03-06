using System.Threading;
using System.Threading.Tasks;

namespace StableCube.DigitalOcean.DotNetClient
{
    public interface IImageEndpoint
    {
        Task<Image[]> GetAllAsync(
            CancellationToken cancellationToken = default(CancellationToken)
        );

        Task<Image[]> GetAllDistributionImagesAsync(
            CancellationToken cancellationToken = default(CancellationToken)
        );
    }
}