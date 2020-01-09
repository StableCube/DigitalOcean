using System;
using Newtonsoft.Json;

namespace StableCube.DigitalOcean.DotNetClient
{
    public class DropletNetworks
    {
        [JsonProperty("v4")]
        public DropletNetwork[] V4 { get; set; }

        [JsonProperty("v6")]
        public DropletNetwork[] V6 { get; set; }
    }
}