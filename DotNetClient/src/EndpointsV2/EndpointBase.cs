using System.Text;
using System.Net.Http;
using Newtonsoft.Json;

namespace StableCube.DigitalOcean.DotNetClient
{
    public abstract class EndpointBase
    {
        protected HttpClient _client;

        public EndpointBase(
            HttpClient client
        )
        {
            _client = client;
        }

        protected StringContent EncodeContent(object input)
        {
            return new StringContent(JsonConvert.SerializeObject(input, new JsonSerializerSettings()
                {
                    TypeNameHandling = TypeNameHandling.Auto
                }), Encoding.UTF8, "application/json");
        }
    }
}