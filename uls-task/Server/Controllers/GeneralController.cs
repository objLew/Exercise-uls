using Microsoft.AspNetCore.Mvc;

namespace uls-task.Server.Controllers
{
    public class GeneralController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
}
