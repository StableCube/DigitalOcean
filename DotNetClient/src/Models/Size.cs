using System;
using Newtonsoft.Json;

namespace StableCube.DigitalOcean.DotNetClient
{
    public class Size
    {
        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("available")]
        public bool Available { get; set; }

        [JsonProperty("transfer")]
        public float Transfer { get; set; }

        [JsonProperty("price_monthly")]
        public float PriceMonthly { get; set; }

        [JsonProperty("price_hourly")]
        public float PriceHourly { get; set; }

        [JsonProperty("memory")]
        public int Memory { get; set; }

        [JsonProperty("vcpus")]
        public int VCPUs { get; set; }

        [JsonProperty("disk")]
        public int Disk { get; set; }

        [JsonProperty("regions")]
        public string[] Regions { get; set; }
    }
}