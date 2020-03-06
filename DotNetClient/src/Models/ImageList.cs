using System;
using Newtonsoft.Json;

namespace StableCube.DigitalOcean.DotNetClient
{
    public class ImageList
    {
        [JsonProperty("images")]
        public Image[] Images { get; set; }
    }
}