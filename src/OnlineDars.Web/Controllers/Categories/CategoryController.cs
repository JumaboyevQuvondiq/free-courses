
using Microsoft.AspNetCore.Mvc;
using OnlineDars.Domain.Entities.Categories;
using OnlineDars.Service.Interfaces.Categories;

namespace OnlineDars.Web.Controllers.Categories
{
    [Route("category")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public async Task<ViewResult> Index()
        {
           var categories = await _categoryService.GetAllAsync();
            return View("Index", categories);
        }
    }
}
