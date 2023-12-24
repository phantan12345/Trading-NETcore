using _62132937_KieuNgocAnh.Aplicaion.Products.DTO;
using _62132937_KieuNgocAnh.Aplicaion.Products;
using Microsoft.AspNetCore.Mvc;
using _62132937_KieuNgocAnh.Applicaion.Categorys;
using _62132937_KieuNgocAnh.Applicaion.Categorys.DTO;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;

namespace _62132937_KieuNgocAnh.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("MyCors")]
    public class CategoryController_62132937 : ControllerBase
    {
        private readonly ICategoryService CategoryService;

        public CategoryController_62132937(ICategoryService categoryService)
        {
            CategoryService = categoryService;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {
            var result = await CategoryService.GetAllAsync();
            return Ok(result);
        }

        [HttpPost("")]
        public async Task<IActionResult> Post(CategoryDto input)
        {
            var result = await CategoryService.Add(input);
            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetAll(int id)
        {
            var result = await CategoryService.GetAsync(id);
            return Ok(result);
        }
    }
    
}
