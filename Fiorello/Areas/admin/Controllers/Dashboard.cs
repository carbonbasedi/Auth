using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fiorello.Areas.admin.Controllers
{
    public class Dashboard : Controller
    {
        [Area("admin")]
        [Route("admin/dashboard/{action=index}")]
        [Authorize(Roles ="SuperAdmin, Admin, MAnager, HR")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
