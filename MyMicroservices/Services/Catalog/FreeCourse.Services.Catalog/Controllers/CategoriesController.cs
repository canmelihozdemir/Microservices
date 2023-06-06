using FreeCourse.Services.Catalog.DTOs;
using FreeCourse.Services.Catalog.Services;
using FreeCourse.Shared.ControllerBases;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FreeCourse.Services.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    internal class CategoriesController : CustomBaseController
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet] public async Task<IActionResult> GetAllAsync() => CreateActionResultInstance(await _categoryService.GetAllAsync());

        [HttpGet("{id}")] public async Task<IActionResult> GetByIdAsync(string id) => CreateActionResultInstance(await _categoryService.GetByIdAsync(id));

        [HttpPost] public async Task<IActionResult> CreateAsync(CategoryDto request) => CreateActionResultInstance(await _categoryService.CreateAsync(request));

    }
}
