using Microsoft.AspNetCore.Mvc;

namespace Fiorello.Areas.admin.Controllers
{
    public class Dashboard : Controller
    {
        [Area("admin")]
        [Route("admin/dashboard/{action=index}")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
