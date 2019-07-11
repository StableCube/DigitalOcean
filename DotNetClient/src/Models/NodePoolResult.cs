using Newtonsoft.Json;

namespace StableCube.DigitalOcean.DotNetClient
{
    public class NodePoolResult
    {
        [JsonProperty("node_pool")]
        public NodePool NodePool { get; set; }
    }
}