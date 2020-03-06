using System;
using Newtonsoft.Json;

namespace StableCube.DigitalOcean.DotNetClient
{
    public class FirewallResult
    {
        [JsonProperty("firewall")]
        public Firewall Firewall { get; set; }
    }
}