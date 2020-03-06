using System;
using Newtonsoft.Json;

namespace StableCube.DigitalOcean.DotNetClient
{
    public class VolumeResult
    {
        [JsonProperty("volume")]
        public Volume Volume { get; set; }
    }
}