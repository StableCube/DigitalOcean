using System;
using Newtonsoft.Json;

namespace StableCube.DigitalOcean.DotNetClient
{
    public class DropletResult
    {
        [JsonProperty("droplet")]
        public Droplet Droplet { get; set; }
    }
}