using System;
using Newtonsoft.Json;

namespace StableCube.DigitalOcean.DotNetClient
{
    public class InboundRule
    {
        [JsonProperty("protocol")]
        public string Protocol { get; set; }

        [JsonProperty("ports")]
        public string Ports { get; set; }

        [JsonProperty("sources")]
        public FirewallTarget Sources { get; set; }
    }
}