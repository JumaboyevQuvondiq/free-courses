using Microsoft.AspNetCore.Mvc;
using OnlineDars.Service.Interfaces.Categories;
using OnlineDars.Service.Interfaces.Videos;

namespace OnlineDars.Web.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admins")]
    public class VideosController : Controller
    {
        private readonly IVideoService _videoService;
        private readonly ICategoryService _categoryService;

        public VideosController(IVideoService videoService, ICategoryService categoryService)
        {
            _videoService = videoService;
            _categoryService = categoryService;
        }
        
        public async Task<IActionResult> IndexAsync()
        {
            var res = await _videoService.GetAllVideosAsync();
            return View("Index", res);
        }
    }
}
