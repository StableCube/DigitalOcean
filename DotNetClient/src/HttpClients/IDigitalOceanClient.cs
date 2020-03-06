
namespace StableCube.DigitalOcean.DotNetClient
{
    public interface IDigitalOceanClient
    {
        IDropletEndpoint DropletEndpoint { get; }

        IFirewallEndpoint FirewallEndpoint { get; }

        IRegionEndpoint RegionEndpoint { get; }

        IKubernetesEndpoint KubernetesEndpoint { get; }

        ISizeEndpoint SizeEndpoint { get; }

        IImageEndpoint ImageEndpoint { get; }

        IBlockStorageEndpoint BlockStorageEndpoint { get; }
    }
}