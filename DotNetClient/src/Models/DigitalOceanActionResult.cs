using System;
using Newtonsoft.Json;

namespace StableCube.DigitalOcean.DotNetClient
{
    public class DigitalOceanActionResult
    {

        [JsonProperty("action")]
        public DigitalOceanAction Action { get; set; }
    }
}