using System;
using Newtonsoft.Json;

namespace StableCube.DigitalOcean.DotNetClient
{
    public class NodePoolListResult
    {
        [JsonProperty("node_pools")]
        public NodePool[] NodePools { get; set; }
    }
}