using System;
using StableCube.DigitalOcean.DotNetClient;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DependencyInjectionExtensions
    {
        public static OptionsBuilder AddDigitalOceanApiClient(
            this IServiceCollection services, Action<ClientOptions> optionsAction)
        {
            ClientOptions ops = new ClientOptions();
            optionsAction.Invoke(ops);

            return new OptionsBuilder(services, ops);
        }
    }
}