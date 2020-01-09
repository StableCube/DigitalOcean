using System;
using Newtonsoft.Json;

namespace StableCube.DigitalOcean.DotNetClient
{
    public class Node
    {
        /// <summary>
        /// A unique ID that can be used to identify and reference the node.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// An automatically generated, human-readable name for the node.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// An object containing a "state" attribute whose value is set to a string indicating 
        /// the current status of the node. Potential values include running, provisioning, and errored.
        /// </summary>
        [JsonProperty("status")]
        public NodeStatus Status { get; set; }

        /// <summary>
        /// A time value given in ISO8601 combined date and time format that represents when the node was created.
        /// </summary>
        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }

        /// <summary>
        /// A time value given in ISO8601 combined date and time format that represents when the node was last updated.
        /// </summary>
        [JsonProperty("updated_at")]
        public string UpdatedAt { get; set; }
    }
}