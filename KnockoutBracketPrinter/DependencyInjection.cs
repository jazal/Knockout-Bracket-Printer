using KnockoutBracketPrinter.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using KnockoutBracketPrinter.Services;

namespace KnockoutBracketPrinter;

public static class DependencyInjection
{
    public static IServiceCollection AddBracketPrinter(this IServiceCollection services)
    {
        // Core services
        services.AddScoped<IBracketPageLayoutService, CustomKnockoutPageLayoutService>();
        services.AddScoped<IBracketPdfPrinter, CustomKnockoutPdfPrinter>();

        services.AddSingleton<HttpClient>();
        services.AddScoped<IFlagImageCache, FlagImageCache>();

        return services;
    }
}
