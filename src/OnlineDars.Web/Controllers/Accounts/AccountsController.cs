using Microsoft.AspNetCore.Mvc;
using OnlineDars.Service.Common.Helpers;
using OnlineDars.Service.Dtos.Accounts;
using OnlineDars.Service.Dtos.Emails;
using OnlineDars.Service.Interfaces.Accounts;

namespace OnlineDars.Web.Controllers.Accounts
{
    [Route("accounts")]
	
    public class AccountsController : Controller
    {
		private readonly IAccountService _service;
		private readonly IVerifyEmailService _emailService;
		public AccountsController(IAccountService acccountService, IVerifyEmailService verifyEmailService)
		{
			this._service = acccountService;
			_emailService = verifyEmailService;
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
				var res = await _service.UserEmailVerifyAsync(accountLoginDto);
					var token = await _service.LoginAsync(accountLoginDto);

					HttpContext.Response.Cookies.Append("X-Access-Token", token, new CookieOptions()
                    {
                        HttpOnly = true,
                        SameSite = SameSiteMode.Strict
                    });
				if(res)
                    return RedirectToAction("Index", "categories", new { area = "" });
				else
				{
					var emailDto = new SendCodeToEmailDto()
					{
						Email = accountLoginDto.Email,	
					};
					await _emailService.SendCodeAsync(emailDto);
					return VerifyEmail(new EmailVerifyDto() { Email = accountLoginDto.Email});
				}
				
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

		[HttpGet("verify-email")]
		public ViewResult VerifyEmail(EmailVerifyDto emailDto)
		{
			return View("VerifyEmail", emailDto);
		}

		[HttpPost("verify-email")]
		public async Task<IActionResult> VerifyEmailAsync(EmailVerifyDto emailVerifyDto)
		{
		
			if (ModelState.IsValid) 
			{
			  var res=	await _emailService.VerifyEmail(emailVerifyDto);

				if (res)
				{
					var result = await _service.VerifyEmailAsync(new AccountLoginDto { Email = emailVerifyDto.Email });
					if (result)
					{
						return RedirectToAction("Index", "categories", new { area = "" });
					}
					return Login();
				}
				return Login();
			}
			return Login();

		}
	}
}
