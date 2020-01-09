using System;
using Newtonsoft.Json;

namespace StableCube.DigitalOcean.DotNetClient
{
    public class NodeStatus
    {
        [JsonProperty("state")]
        public string State { get; set; }
    }
}