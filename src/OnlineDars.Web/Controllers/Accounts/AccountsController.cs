using Microsoft.AspNetCore.Mvc;
using OnlineDars.Service.Common.Helpers;
using OnlineDars.Service.Dtos.Accounts;
using OnlineDars.Service.Interfaces.Accounts;

namespace OnlineDars.Web.Controllers.Accounts
{
    [Route("accounts")]
	
    public class AccountsController : Controller
    {
		private readonly IAccountService _service;
		public AccountsController(IAccountService acccountService)
		{
			this._service = acccountService;
		}
		[HttpGet("login")]
        public ViewResult Login()
        {
            return View("Login");
        }

		[HttpPost("login")]
		public async Task<IActionResult> LoginAsync(AccountLoginDto accountLoginDto)
		{
			if (ModelState.IsValid)
			{
				var token = await _service.LoginAsync(accountLoginDto);
				HttpContext.Response.Cookies.Append("X-Access-Token", token, new CookieOptions()
				{
					HttpOnly= true,
					SameSite = SameSiteMode.Strict
				});
				return RedirectToAction("Index", "categories", new { area = "" });
			}
			return Login();
		}

		[HttpGet("register")]
        public ViewResult Register()
        {
            return View("Register");
        }
		

		[HttpPost("register")]
		public async Task<IActionResult> RegisterAsync(AccountRegisterDto accountRegisterDto)
		{
			if (ModelState.IsValid)
			{
				bool result = await _service.RegisterAsync(accountRegisterDto);
				if (result)
				{
					return RedirectToAction("login", "accounts", new { area = "" });
				}
				else
				{
					return Register();
				}
			}
			else return Register();
		}

		[HttpGet("logout")]
		public IActionResult LogOut()
		{
			HttpContext.Response.Cookies.Append("X-Access-Token", "", new CookieOptions()
			{
				Expires = TimeHelper.GetCurrentServerTime().AddDays(-1)
			});
			return RedirectToAction("Login", "Accounts", new { area = "" });
		}
	}
}
