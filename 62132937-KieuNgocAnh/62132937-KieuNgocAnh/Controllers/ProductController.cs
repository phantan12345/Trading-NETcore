using _62132937_KieuNgocAnh.Aplicaion.Products;
using _62132937_KieuNgocAnh.Aplicaion.Products.DTO;
using _62132937_KieuNgocAnh.Aplicaion.Users;
using _62132937_KieuNgocAnh.Models;
using _62132937_KieuNgocAnh.Models.Entity;
using Microsoft.AspNetCore.Mvc;

namespace _62132937_KieuNgocAnh.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService ProductService;

        private readonly IUserService UserService;

        public ProductController(IUserService userService, IProductService productService)
        {
            ProductService = productService;
            UserService = userService;  
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {
            var result = await ProductService.GetAllAsync();
            return Ok(result);
        }

        [HttpPost("")]
        public async Task<IActionResult> Post(IFormCollection form, IFormFile file)
        {
            try
            {
                if (file == null || file.Length == 0)
                {
                    return BadRequest("Invalid file");
                }

                var filePath = Path.Combine("Images", file.FileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                var input = new ProductDto(form["name"], double.Parse(form["price"]) , filePath, int.Parse(form["categoryId"]));

                var user = await UserService.GetAsyncByUserName(HttpContext.User.Identity.Name);
                if(user != null)
                {
                    return BadRequest("User Null");
                }
                var result = await ProductService.Add(input, user);
                return Ok(filePath);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetAll(int id)
        {
            var result = await ProductService.GetAsync(id   );
            return Ok(result);
        }
    }
}
