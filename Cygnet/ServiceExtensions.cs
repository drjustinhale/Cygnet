namespace Cygnet;

using Models;

/// <summary>Extensions to the IServiceCollection to configure the mvc pipeline.</summary>
public static class ServiceExtensions {

    public static IServiceCollection AddDependencyInjection(this IServiceCollection services) {
        services.AddHttpContextAccessor();
        services.AddTransient<IGreeting, DefaultGreeting>();

        return services;
    }

}