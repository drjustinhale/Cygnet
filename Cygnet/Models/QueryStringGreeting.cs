namespace Cygnet.Models;

/// <summary>A greeting when a query string is present.</summary>
public class QueryStringGreeting : IGreeting {

    /// <summary>The greeting to use.</summary>
    public string Greet => "QueryStringGreeting";

}