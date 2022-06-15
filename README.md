Cygnet
=

Cygnet is an experiment of dependency injection (DI) to vary the classes that it injects into a controller based on a query string.

# Code

The `HomeController` constructor has a dependency which is provided by the DI.
```csharp
public HomeController(IGreeting greeting) {
    _greeting = greeting;
}
```

There are two classes that implement the the `IGreeting` dependency, `DefaultGreeting` and `QueryStringGreeting`.

`ServiceExtensions.cs` method `AddDependencyInjectionBasedOnQueryString(...)` is invoked for every HTTP request. It modifies the DI to return different instantiated classes depending on the presence of a query string.

```csharp
    /// <summary>Configure dependency injection to inject different configs based on the presence of a query string.</summary>
    private static IGreeting AddDependencyInjectionBasedOnQueryString(IServiceProvider provider) {
        var context = provider.GetRequiredService<IHttpContextAccessor>();
        var hasQueryString = context.HttpContext?.Request.Query.Count != 0;

        if (hasQueryString)
            return provider.GetRequiredService<QueryStringGreeting>();
        return provider.GetRequiredService<DefaultGreeting>();
    }
```

# Use


Browse the solution, eg `http://localhost:5070/`, and `DefaultGreeting` will be injected in to the `HomeController` constructor. The text "DefaultGreeting" will be returned.

Add a query string to the request, eg `http://localhost:5070/?q`, and `QueryStringGreeting` will be injected in to the `HomeController` constructor. The text "QueryStringConfig" will be returned.