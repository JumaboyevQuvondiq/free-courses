
using Microsoft.AspNetCore.Mvc;
using OnlineDars.Domain.Entities.Categories;
using OnlineDars.Service.Interfaces.Categories;
using System.Runtime.CompilerServices;

namespace OnlineDars.Web.Controllers.Categories
{
    [Route("category")]
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;

        
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet]
        public async Task<ViewResult> Index()
        {
           var categories = await _categoryService.GetAllAsync();
            return View("Index", categories);
        }
        
    }
}
