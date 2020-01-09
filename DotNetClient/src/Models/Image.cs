using System;
using Newtonsoft.Json;

namespace StableCube.DigitalOcean.DotNetClient
{
    public class Image
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

       [JsonProperty("distribution")]
        public string Distribution { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("public")]
        public bool Public { get; set; }

        [JsonProperty("regions")]
        public string[] Regions { get; set; }

        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }

        [JsonProperty("min_disk_size")]
        public int MinDiskSize { get; set; }

        [JsonProperty("size_gigabytes")]
        public float SizeGigabytes { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("tags")]
        public string[] Tags { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("error_message")]
        public string ErrorMessage { get; set; }
    }
}