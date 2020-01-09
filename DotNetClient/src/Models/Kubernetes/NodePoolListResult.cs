using System;
using Newtonsoft.Json;

namespace StableCube.DigitalOcean.DotNetClient
{
    public class NodePoolListResult
    {
        [JsonProperty("node_pools", NullValueHandling = NullValueHandling.Ignore)]
        public NodePool[] NodePools { get; set; } = new NodePool[0];
    }
}