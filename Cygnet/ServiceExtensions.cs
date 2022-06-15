namespace Cygnet;

using Models;

/// <summary>Extensions to the IServiceCollection to configure the mvc pipeline.</summary>
public static class ServiceExtensions {

    public static IServiceCollection AddDependencyInjection(this IServiceCollection services) {
        services.AddHttpContextAccessor();
        services.AddSingleton<DefaultGreeting>();
        services.AddSingleton<QueryStringGreeting>();
        services.AddScoped(AddDependencyInjectionBasedOnQueryString);
        return services;
    }

    /// <summary>Configure dependency injection to inject different configs based on the presence of a query string.</summary>
    private static IGreeting AddDependencyInjectionBasedOnQueryString(IServiceProvider provider) {
        var context = provider.GetRequiredService<IHttpContextAccessor>();
        var hasQueryString = context.HttpContext?.Request.Query.Count != 0;

        if (hasQueryString)
            return provider.GetRequiredService<QueryStringGreeting>();
        return provider.GetRequiredService<DefaultGreeting>();
    }

}