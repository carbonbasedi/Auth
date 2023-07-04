using Microsoft.AspNetCore.Mvc;

namespace Fiorello.Controllers
{
	public class AboutUsController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
