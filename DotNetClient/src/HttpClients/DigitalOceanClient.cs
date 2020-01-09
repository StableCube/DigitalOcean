using System.Net.Http;

namespace StableCube.DigitalOcean.DotNetClient
{
    public class DigitalOceanClient : IDigitalOceanClient
    {
        public IDropletEndpoint DropletEndpoint { get; private set; }
        public IKubernetesEndpoint KubernetesEndpoint { get; private set; }

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
            KubernetesEndpoint = new KubernetesEndpoint(_client);
        }
    }
}