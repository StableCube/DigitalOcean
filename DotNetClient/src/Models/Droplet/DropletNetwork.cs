using System;
using Newtonsoft.Json;

namespace StableCube.DigitalOcean.DotNetClient
{
    public class DropletNetwork
    {
        [JsonProperty("ip_address")]
        public string IpAddress { get; set; }

        [JsonProperty("netmask")]
        public string Netmask { get; set; }

        [JsonProperty("gateway")]
        public string Gateway { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}