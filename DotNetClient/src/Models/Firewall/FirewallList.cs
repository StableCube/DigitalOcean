using System;
using Newtonsoft.Json;

namespace StableCube.DigitalOcean.DotNetClient
{
    public class FirewallList
    {
        [JsonProperty("firewalls")]
        public Firewall[] Firewalls { get; set; }
    }
}