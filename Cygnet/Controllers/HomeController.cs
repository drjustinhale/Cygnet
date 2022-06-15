namespace Cygnet.Controllers;

using Microsoft.AspNetCore.Mvc;
using Models;

public class HomeController : Controller {

    #region Constructors

    private readonly IGreeting _greeting;

    /// <summary>Use dependency injection to provide instance of IGreeting.</summary>
    public HomeController(IGreeting greeting) {
        _greeting = greeting;
    }

    #endregion

    [HttpGet]
    public async Task Index() {
        await Response.WriteAsync(_greeting.Greet);
    }

}