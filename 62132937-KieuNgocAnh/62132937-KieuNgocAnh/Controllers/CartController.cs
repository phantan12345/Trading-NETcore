using Microsoft.AspNetCore.Mvc;
using _62132937_KieuNgocAnh.Applicaion.Carts;
using _62132937_KieuNgocAnh.Aplicaion.Users;
using Microsoft.AspNetCore.Cors;

namespace _62132937_KieuNgocAnh.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("MyCors")]
    public class CartController : ControllerBase
    {
        private readonly IUserService UserService;

        private readonly ICartService CartService;
        public CartController (IUserService userService, ICartService cartService)
        {
            CartService = cartService;
            UserService= userService;
        }
        [HttpPost("")]
        public async Task<IActionResult> Add(List<CartDto> input)
        {
            var user = await UserService.GetAsyncByUserName(HttpContext.User.Identity.Name);

            var result = await CartService.AddCart(input, user);
            return Ok(result);
        }
    }
}


 
