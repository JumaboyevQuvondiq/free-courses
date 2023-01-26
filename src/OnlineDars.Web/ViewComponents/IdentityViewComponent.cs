using Microsoft.AspNetCore.Mvc;
using OnlineDars.Service.Interfaces.Common;
using OnlineDars.Service.ViewModels.Accounts;

namespace OnlineDars.Web.ViewComponents
{
	public class IdentityViewComponent : ViewComponent
	{
		private readonly IIdentityService _identityService;
		public IdentityViewComponent(IIdentityService identityService)
		{
			_identityService = identityService;
		}
		public IViewComponentResult Invoke()
		{
			AccountBaseViewModel accountBaseViewModel = new AccountBaseViewModel()
			{
				Id= _identityService.Id!.Value,
				FirstName = _identityService.Name,
				ImagePath = _identityService.ImagePath
			};	

			return View(accountBaseViewModel);
		}
	}
}
