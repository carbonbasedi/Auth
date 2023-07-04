using Fiorello.Models;
using Fiorello.ViewModels.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Fiorello.Controllers
{
	public class AccountController : Controller
	{
		private readonly UserManager<User> _userManager;

		public AccountController(UserManager<User> userManager)
        {
			_userManager = userManager;
		}
        [HttpGet]
		public IActionResult Register()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Register(AccountRegisterVM model)
		{
			if(!ModelState.IsValid) return View();

			var user = new User
			{
				UserName = model.Username,
				Email = model.Email,
				Country = model.Country,
				FullName = model.Fullname,
				PhoneNumber = model.PhoneNumber,
			};

			var result = _userManager.CreateAsync(user, model.Password).Result;

			if(!result.Succeeded)
			{
				foreach (var error in result.Errors)
					ModelState.AddModelError(string.Empty, error.Description);

				return View();
			}

			return RedirectToAction(nameof(Login));
		}

		[HttpGet]
		public IActionResult Login()
		{
			return Ok();
		}
	}
}
