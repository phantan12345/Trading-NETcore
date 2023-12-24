using _62132937_KieuNgocAnh.Aplicaion.Products;
using _62132937_KieuNgocAnh.Aplicaion.Products.DTO;
using _62132937_KieuNgocAnh.Aplicaion.Users;
using _62132937_KieuNgocAnh.Applicaion.Products.DTO;
using _62132937_KieuNgocAnh.Models;
using _62132937_KieuNgocAnh.Models.Entity;
using CloudinaryDotNet;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _62132937_KieuNgocAnh.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("MyCors")]
    [Authorize]
    public class ProductController_62132937 : ControllerBase
    {
        private readonly IProductService ProductService;

        private readonly IUserService UserService;

        public ProductController_62132937(IUserService userService, IProductService productService)
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
        public async Task<IActionResult> Post([FromForm]ProductDto form)
        {
            try
            {
                if (form.File == null || form.File.Length == 0)
                {
                    return BadRequest("Invalid file");
                }

                var filePath = Path.Combine("", form.File.FileName);

                using (var stream = new FileStream("Images\\"+filePath, FileMode.Create))
                {
                    await form.File.CopyToAsync(stream);
                }

                var input = new ProductDto(form.Name, form.Price,form.CategoryId);
                input.SetImage(filePath);

                var user = await UserService.GetAsyncByUserName(HttpContext.User.Identity.Name);
                //if(user == null)
                //{
                //    return BadRequest("User Null");
                //}
                var result = await ProductService.Add(input);
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


        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] SearchParams param )
        {
            var result = await ProductService.Search(param);
            return Ok(result);
        }
    }
}
