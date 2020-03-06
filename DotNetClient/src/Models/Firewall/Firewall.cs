using System;
using Newtonsoft.Json;

namespace StableCube.DigitalOcean.DotNetClient
{
    public class Firewall
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("inbound_rules")]
        public InboundRule[] InboundRules { get; set; }

        [JsonProperty("outbound_rules")]
        public OutboundRule[] OutboundRules { get; set; }

        [JsonProperty("droplet_ids")]
        public int[] DropletIds { get; set; }

        [JsonProperty("tags")]
        public string[] Tags { get; set; }
    }
}