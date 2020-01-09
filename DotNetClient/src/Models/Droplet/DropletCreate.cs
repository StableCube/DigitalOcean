using System;
using Newtonsoft.Json;

namespace StableCube.DigitalOcean.DotNetClient
{
    public class DropletCreate
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("region")]
        public string Region { get; set; }

        [JsonProperty("size")]
        public string Size { get; set; }

        /// <summary>
        /// The image ID of a public or private image, or the unique slug identifier for a public image. 
        /// This image will be the base image for your Droplet.
        /// </summary>
        [JsonProperty("image")]
        public int Image { get; set; }

        /// <summary>
        /// An array containing the IDs or fingerprints of the SSH keys that you wish to embed 
        /// in the Droplet's root account upon creation.
        /// </summary>
        [JsonProperty("ssh_keys")]
        public string[] SshKeys { get; set; }

        /// <summary>
        /// A boolean indicating whether automated backups should be enabled for the Droplet. 
        /// Automated backups can only be enabled when the Droplet is created.
        /// </summary>
        [JsonProperty("backups")]
        public bool Backups { get; set; }

        [JsonProperty("ipv6")]
        public bool Ipv6 { get; set; }
        
        /// <summary>
        /// A boolean indicating whether private networking is enabled for the Droplet. 
        /// Private networking is currently only available in certain regions.
        /// </summary>
        [JsonProperty("private_networking")]
        public bool PrivateNetworking { get; set; }

        /// <summary>
        /// A string containing 'user data' which may be used to configure the Droplet on first boot, 
        /// often a 'cloud-config' file or Bash script. It must be plain text and may not exceed 64 KiB in size.
        /// </summary>
        [JsonProperty("user_data")]
        public string UserData { get; set; }

        [JsonProperty("monitoring")]
        public bool Monitoring { get; set; }

        /// <summary>
        /// A flat array including the unique string identifier for each Block Storage volume to be attached to the Droplet. 
        /// At the moment a volume can only be attached to a single Droplet.
        /// </summary>
        [JsonProperty("volumes")]
        public string[] Volumes { get; set; }

        /// <summary>
        /// A flat array of tag names as strings to apply to the Droplet after it is created. 
        /// Tag names can either be existing or new tags.
        /// </summary>
        [JsonProperty("tags")]
        public string[] Tags { get; set; }
    }
}