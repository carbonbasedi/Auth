using Fiorello.Enums;
using Fiorello.Models;
using Fiorello.ViewModels.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Fiorello.Controllers
{
	public class AccountController : Controller
	{
		private readonly UserManager<User> _userManager;
		private readonly SignInManager<User> _signInManager;
		private readonly RoleManager<IdentityRole> _roleManager;

		public AccountController(UserManager<User> userManager,
								SignInManager<User> signInManager,
								RoleManager<IdentityRole> roleManager)
		{
			_userManager = userManager;
			_signInManager = signInManager;
			_roleManager = roleManager;
		}
		[HttpGet]
		public IActionResult Register()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Register(AccountRegisterVM model)
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

			var result = await _userManager.CreateAsync(user, model.Password);

			if(!result.Succeeded)
			{
				foreach (var error in result.Errors)
					ModelState.AddModelError(string.Empty, error.Description);

				return View();
			}

			await _userManager.AddToRoleAsync(user, UserRoles.User.ToString());
			return RedirectToAction(nameof(Login));
		}

		[HttpGet]
		public IActionResult Login()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Login(AccountLoginVM model)
		{
			if (!ModelState.IsValid) return View();

			var user = await _userManager.FindByNameAsync(model.Username);

			if(user is null)
			{
				ModelState.AddModelError(string.Empty, "Username or password is incorrect");
				return View();
			}

			var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);
			if(!result.Succeeded)
			{
				ModelState.AddModelError(string.Empty, "Username or password is incorrect"); 
				return View();
			}

			if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
				return Redirect(model.ReturnUrl);

			return RedirectToAction(nameof(Index),"home");
		}

		[HttpGet]
		public async Task<IActionResult> Logout()
		{
			await _signInManager.SignOutAsync();
			return RedirectToAction(nameof(Login));
		}
	}
}
