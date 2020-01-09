using System;
using Newtonsoft.Json;

namespace StableCube.DigitalOcean.DotNetClient
{
    public class DropletList
    {
        [JsonProperty("droplets")]
        public Droplet[] Droplets { get; set; }
    }
}