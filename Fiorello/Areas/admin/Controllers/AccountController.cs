using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fiorello.Areas.admin.Controllers
{
	[Area("admin")]
	[Authorize(Roles = "SuperAdmin, Admin, Manager, HR")]
 	public class AccountController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
