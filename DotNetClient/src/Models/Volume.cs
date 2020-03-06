using System;
using Newtonsoft.Json;

namespace StableCube.DigitalOcean.DotNetClient
{
    public class Volume
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("region")]
        public Region Region { get; set; }

        [JsonProperty("droplet_ids")]
        public string[] DropletIds { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("size_gigabytes")]
        public int SizeGigabytes { get; set; }

        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }

        [JsonProperty("filesystem_type")]
        public string FilesystemType { get; set; }

        [JsonProperty("filesystem_label")]
        public string FilesystemLabel { get; set; }

        [JsonProperty("tags")]
        public string[] Tags { get; set; }
    }
}