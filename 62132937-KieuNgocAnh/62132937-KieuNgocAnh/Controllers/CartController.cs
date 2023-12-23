using Microsoft.AspNetCore.Mvc;
using _62132937_KieuNgocAnh.Applicaion.Carts;
using _62132937_KieuNgocAnh.Aplicaion.Users;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;

namespace _62132937_KieuNgocAnh.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("MyCors")]
    [Authorize]
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
        public async Task<IActionResult> Add(CartDto input)
        {
            var user = await UserService.GetAsyncByUserName(HttpContext.User.Identity.Name);

            var result = await CartService.AddCart(input, user);
            return Ok(result);
        }
    }
}


 
