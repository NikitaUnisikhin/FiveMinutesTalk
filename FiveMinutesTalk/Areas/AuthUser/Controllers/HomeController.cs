using Microsoft.AspNetCore.Mvc;

namespace FiveMinutesTalk.Areas.Admin.Controllers;

[Area("AuthUser")]
public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View("~/Areas/AuthUser/Views/Index.cshtml");
    }
}