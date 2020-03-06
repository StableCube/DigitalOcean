using System;
using Newtonsoft.Json;

namespace StableCube.DigitalOcean.DotNetClient
{
    public class FirewallTarget
    {
        [JsonProperty("addresses")]
        public string[] Addresses { get; set; }

        [JsonProperty("droplet_ids")]
        public int[] DropletIds { get; set; }

        [JsonProperty("load_balancer_uids")]
        public string[] LoadBalancerUids { get; set; }

        [JsonProperty("tags")]
        public string[] Tags { get; set; }
    }
}