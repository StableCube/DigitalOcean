using System;
using Newtonsoft.Json;

namespace StableCube.DigitalOcean.DotNetClient
{
    public class Region
    {
        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("sizes")]
        public string[] Sizes { get; set; }

       [JsonProperty("available")]
        public bool Available { get; set; }

        [JsonProperty("features")]
        public string[] Features { get; set; }
    }
}