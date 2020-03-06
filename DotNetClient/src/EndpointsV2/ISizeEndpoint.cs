using System.Threading;
using System.Threading.Tasks;

namespace StableCube.DigitalOcean.DotNetClient
{
    public interface ISizeEndpoint
    {
        Task<Size[]> GetAllAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}