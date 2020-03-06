using System;
using Newtonsoft.Json;

namespace StableCube.DigitalOcean.DotNetClient
{
    public class VolumeList
    {
        [JsonProperty("volumes")]
        public Volume[] Volumes { get; set; }
    }
}