using System;
using Newtonsoft.Json;

namespace StableCube.DigitalOcean.DotNetClient
{
    public class Droplet
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("memory")]
        public int Memory { get; set; }

        [JsonProperty("vcpus")]
        public int VCPUs { get; set; }

        [JsonProperty("disk")]
        public int Disk { get; set; }

        [JsonProperty("locked")]
        public bool Locked { get; set; }

        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("backup_ids")]
        public string[] BackupIds { get; set; }

        [JsonProperty("snapshot_ids")]
        public string[] SnapshotIds { get; set; }

        [JsonProperty("features")]
        public string[] Features { get; set; }

        [JsonProperty("region")]
        public Region Region { get; set; }

        [JsonProperty("image")]
        public Image Image { get; set; }

        [JsonProperty("size")]
        public Size Size { get; set; }

        [JsonProperty("size_slug")]
        public string SizeSlug { get; set; }

        [JsonProperty("networks")]
        public DropletNetworks Networks { get; set; }

        [JsonProperty("tags")]
        public string[] Tags { get; set; }

        [JsonProperty("volume_ids")]
        public string[] VolumeIds { get; set; }
    }
}