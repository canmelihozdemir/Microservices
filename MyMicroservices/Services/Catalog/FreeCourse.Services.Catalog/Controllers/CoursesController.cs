using FreeCourse.Services.Catalog.DTOs;
using FreeCourse.Services.Catalog.Services;
using FreeCourse.Shared.ControllerBases;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FreeCourse.Services.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    internal class CoursesController : CustomBaseController
    {
        private readonly ICourseService _courseService;

        public CoursesController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet] public async Task<IActionResult> GetAllAsync() => CreateActionResultInstance(await _courseService.GetAllAsync());

        [HttpGet("{id}")] public async Task<IActionResult> GetByIdAsync(string id) => CreateActionResultInstance(await _courseService.GetByIdAsync(id));

        [Route("/api/[controller]/GetAllByUserIdAsync/{userId}")] public async Task<IActionResult> GetAllByUserIdAsync(string userId) => CreateActionResultInstance(await _courseService.GetAllByUserIdAsync(userId));

        [HttpPost] public async Task<IActionResult> CreateAsync(CourseCreateDto request) => CreateActionResultInstance(await _courseService.CreateAsync(request));

        [HttpPut] public async Task<IActionResult> UpdateAsync(CourseUpdateDto request) => CreateActionResultInstance(await _courseService.UpdateAsync(request));

        [HttpDelete("{id}")] public async Task<IActionResult> DeleteAsync(string id) => CreateActionResultInstance(await _courseService.DeleteAsync(id));

    }
}
