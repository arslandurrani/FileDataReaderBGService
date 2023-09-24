using FileDataReaderBGService.DBContext;
using FileDataReaderBGService.Repositories;
using FileDataReaderBGService.Services;
using FileDataReaderBGService.Utilities;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using System.Threading.Tasks;

namespace FileDataReaderBGService;

public static class AppDI
{
    private static IHost _host;

    public static void BuildHostService()
    {
        _host = CreateHostBuilder().Build();
    }

    public static T GetRequiredService<T>()
    {
        return _host.Services.GetRequiredService<T>();
    }

    public static async Task StartHostedService()
    {
        await _host.StartAsync();
    }

    public static async Task StopHostedService()
    {
        await _host.StopAsync();
    }

    private static void ConfigureAppServices(IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>(contextLifetime: ServiceLifetime.Singleton, optionsLifetime: ServiceLifetime.Singleton);

        services.AddSingleton<ELDEventsRepository>();
        services.AddSingleton<ELDEventsServerRepository>();

        services.AddAutoMapper(typeof(ELDEventsMapper));

        // add ELDEventsServer Service to sync record with other table, but it will only run when sync event is invoked
        services.AddSingleton<ELDEventsServerService>();
    }

    private static IHostBuilder CreateHostBuilder() =>
        Host.CreateDefaultBuilder()
            .ConfigureServices((hostContext, services) =>
            {
                // Configure App Service like DB context, Repos etc
                ConfigureAppServices(services);

                services.AddHostedService<ELDEventsBGService>();
            });

}
