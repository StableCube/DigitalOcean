using Newtonsoft.Json;

namespace StableCube.DigitalOcean.DotNetClient
{
    public class NodePool
    {
        /// <summary>
        /// A unique ID that can be used to identify and reference a specific node pool.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// A human-readable name for the node pool.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// The slug identifier for the type of Droplet used as workers in the node pool.
        /// </summary>
        [JsonProperty("size")]
        public string Size { get; set; }

        /// <summary>
        /// The number of Droplet instances in the node pool.
        /// </summary>
        [JsonProperty("count")]
        public int Count { get; set; }

        /// <summary>
        /// An array containing the tags applied to the node pool. 
        /// All node pools are automatically tagged "k8s," "k8s-worker," and "k8s:$K8S_CLUSTER_ID."
        /// </summary>
        [JsonProperty("tags", NullValueHandling = NullValueHandling.Ignore)]
        public string[] Tags { get; set; } = new string[0];

        /// <summary>
        /// An object specifying the details of a specific worker node in a node pool
        /// </summary>
        [JsonProperty("nodes", NullValueHandling = NullValueHandling.Ignore)]
        public Node[] Nodes { get; set; } = new Node[0];
    }
}