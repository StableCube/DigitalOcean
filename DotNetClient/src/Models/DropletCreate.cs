using System;
using Newtonsoft.Json;

namespace StableCube.DigitalOcean.DotNetClient
{
    public class BlockStorageVolCreate
    {

        [JsonProperty("size_gigabytes")]
        public int SizeGigabytes { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("region")]
        public string Region { get; set; }

        [JsonProperty("snapshot_id")]
        public string SnapshotId { get; set; }

        [JsonProperty("filesystem_type")]
        public string FilesystemType { get; set; }

        [JsonProperty("filesystem_label")]
        public string FilesystemLabel { get; set; }

        [JsonProperty("tags")]
        public string[] Tags { get; set; }
    }
}