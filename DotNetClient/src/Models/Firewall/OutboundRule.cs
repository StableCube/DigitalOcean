using System;
using Newtonsoft.Json;

namespace StableCube.DigitalOcean.DotNetClient
{
    public class OutboundRule
    {
        [JsonProperty("protocol")]
        public string Protocol { get; set; }

        [JsonProperty("ports")]
        public string Ports { get; set; }

        [JsonProperty("destinations")]
        public FirewallTarget Destinations { get; set; }
    }
}