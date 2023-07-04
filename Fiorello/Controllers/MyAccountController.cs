using Microsoft.AspNetCore.Mvc;

namespace Fiorello.Controllers
{
	public class MyAccountController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
