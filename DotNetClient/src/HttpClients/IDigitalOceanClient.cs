using System.Threading;
using System.Threading.Tasks;

namespace StableCube.DigitalOcean.DotNetClient
{
    public interface IDigitalOceanClient
    {
        IDropletEndpoint DropletEndpoint { get; }
        IKubernetesEndpoint KubernetesEndpoint { get; }
    }
}