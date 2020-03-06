using System.Net.Http;

namespace StableCube.DigitalOcean.DotNetClient
{
    public class DigitalOceanClient : IDigitalOceanClient
    {
        public IDropletEndpoint DropletEndpoint { get; private set; }
        public IFirewallEndpoint FirewallEndpoint { get; private set; }
        public IRegionEndpoint RegionEndpoint { get; private set; }
        public IKubernetesEndpoint KubernetesEndpoint { get; private set; }
        public ISizeEndpoint SizeEndpoint { get; private set; }
        public IImageEndpoint ImageEndpoint { get; private set; }
        public IBlockStorageEndpoint BlockStorageEndpoint { get; private set; }

        private HttpClient _client;
        private ClientOptions _clientOptions;

        public DigitalOceanClient(
            HttpClient client,
            ClientOptions options
        )
        {
            _client = client;
            _clientOptions = options;

            DropletEndpoint = new DropletEndpoint(_client);
            FirewallEndpoint = new FirewallEndpoint(_client);
            RegionEndpoint = new RegionEndpoint(_client);
            KubernetesEndpoint = new KubernetesEndpoint(_client);
            SizeEndpoint = new SizeEndpoint(_client);
            ImageEndpoint = new ImageEndpoint(_client);
            BlockStorageEndpoint = new BlockStorageEndpoint(_client);
        }
    }
}