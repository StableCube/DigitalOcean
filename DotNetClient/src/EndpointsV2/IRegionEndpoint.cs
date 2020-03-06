using System.Threading;
using System.Threading.Tasks;

namespace StableCube.DigitalOcean.DotNetClient
{
    public interface IRegionEndpoint
    {
        Task<Region[]> GetAllAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}