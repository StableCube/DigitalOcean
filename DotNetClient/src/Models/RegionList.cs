using System;
using Newtonsoft.Json;

namespace StableCube.DigitalOcean.DotNetClient
{
    public class RegionList
    {
        [JsonProperty("regions")]
        public Region[] Regions { get; set; }
    }
}