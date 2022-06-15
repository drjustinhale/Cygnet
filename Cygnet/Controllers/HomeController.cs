namespace Cygnet.Controllers;

using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller {

    [HttpGet]
    public async Task Index() {
        await Response.WriteAsync("Hello, World!");
    }

}