using System;
using Newtonsoft.Json;

namespace StableCube.DigitalOcean.DotNetClient
{
    public class SizeList
    {
        [JsonProperty("sizes")]
        public Size[] Sizes { get; set; }
    }
}