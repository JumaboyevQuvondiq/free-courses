using Microsoft.AspNetCore.Mvc;
using OnlineDars.Service.Interfaces.Videos;
using OnlineDars.Web.Models;
using System.Diagnostics;

namespace OnlineDars.Web.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
        private readonly IVideoService _videoService;

        public HomeController(ILogger<HomeController> logger, IVideoService videoService)
		{
			_logger = logger;
			_videoService = videoService;
		}

		public async Task<ViewResult> Index()
		{
			var video = await _videoService.GetAsync(1);
			return View(video);
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}