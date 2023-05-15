using Microsoft.AspNetCore.Mvc;

namespace FiveMinutesTalk.Areas.Admin.Controllers;

[Area("User")]
public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View("~/Areas/User/Views/Index.cshtml");
    }
}