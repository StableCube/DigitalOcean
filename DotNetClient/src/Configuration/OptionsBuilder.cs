using System;
using Microsoft.Extensions.DependencyInjection;

namespace StableCube.DigitalOcean.DotNetClient
{
    public class OptionsBuilder
    {
        private IServiceCollection _services;
        private ClientOptions _options;
        
        public OptionsBuilder(IServiceCollection services, ClientOptions options)
        {
            _services = services;
            _options = options;

            services.AddSingleton(options);
            
            _services.AddHttpClient<IKubernetesClient, KubernetesClient>(clientConfig => {
                clientConfig.BaseAddress = new Uri("https://api.digitalocean.com");
                clientConfig.DefaultRequestHeaders.Add("User-Agent", "StableCube.DigitalOceanClient");
                clientConfig.DefaultRequestHeaders.Add("Authorization", $"Bearer {options.AccessToken}");
            });
        }
    }
}
