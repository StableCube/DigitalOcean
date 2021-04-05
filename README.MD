# About

C# client for the DigitalOcean api. API coverage is not 100% but will improve as I need additional endpoints. Feel free to flesh out api coverage with a pull request.

## Install 

Install the [Nuget package](https://www.nuget.org/packages/StableCube.DigitalOcean.DotNetClient/) then register service in DI and pass it your access token.

#### Startup.cs
```C#
services.AddDigitalOceanApiClient(options => {
    options.AccessToken = <PUT_ACCESS_TOKEN_HERE>;
});
```

## Usage

```C#
using StableCube.DigitalOcean.DotNetClient;

public class ClientExample
{
    private IDigitalOceanClient _doClient;

    public ClientExample(IDigitalOceanClient doClient)
    {
        _doClient = doClient;
    }

    public async Task DoExampleStuffAsync(
        CancellationToken cancellationToken = default(CancellationToken)
    )
    {
        // List regions
        var regions = await _doClient.RegionEndpoint
            .GetAllAsync(cancellationToken);

        foreach (var region in regions)
        {
            Console.WriteLine(region.Slug);
        }

        // List droplets
        DropletList droplets = await _doClient.DropletEndpoint
            .GetAllAsync(cancellationToken);

        foreach (var droplet in droplets)
        {
            Console.WriteLine(droplet.Name);
        }
    }
}
```