using System;
using Newtonsoft.Json;

namespace StableCube.DigitalOcean.DotNetClient
{
    public class VolumeDetach
    {
        [JsonProperty("type")]
        public string Type { get { return "detach"; } }

        /// <summary>
        /// The unique identifier for the Droplet the volume will be attached or detached from.
        /// </summary>
        [JsonProperty("droplet_id")]
        public int DropletId { get; set; }

        /// <summary>
        /// The name of the Block Storage volume.
        /// </summary>
        [JsonProperty("volume_name")]
        public string VolumeName { get; set; }

        /// <summary>
        /// The slug identifier for the region the volume is located in.
        /// </summary>
        [JsonProperty("region")]
        public string Region { get; set; }
    }
}