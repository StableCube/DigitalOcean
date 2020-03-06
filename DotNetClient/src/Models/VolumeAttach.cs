using System;
using Newtonsoft.Json;

namespace StableCube.DigitalOcean.DotNetClient
{
    public class VolumeAttach
    {
        [JsonProperty("type")]
        public string Type { get { return "attach"; } }

        /// <summary>
        /// The unique identifier for the Droplet the volume will be attached or detached from.
        /// </summary>
        [JsonProperty("droplet_id")]
        public int DropletId { get; set; }

        /// <summary>
        /// The slug identifier for the region the volume is located in.
        /// </summary>
        [JsonProperty("region")]
        public string Region { get; set; }
    }
}