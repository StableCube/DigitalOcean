using System;
using System.Net.Http;

namespace StableCube.DigitalOcean.DotNetClient
{
    public class DigitalOceanApiCallException : Exception
    {
        public DigitalOceanApiCallException(ApiErrorResult error) : base(error.ToString())
        {
        }
    }
}
