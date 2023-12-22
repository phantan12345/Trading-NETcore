using _62132937_KieuNgocAnh.Aplicaion.Products;
using _62132937_KieuNgocAnh.Aplicaion.Users;
using _62132937_KieuNgocAnh.Applicaion.Stores;
using _62132937_KieuNgocAnh.Applicaion.Stores.DTO;
using Microsoft.AspNetCore.Mvc;

namespace _62132937_KieuNgocAnh.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController:ControllerBase
    {
        private readonly IStoreService StoreService;
        private readonly IUserService UserService;
        public StoreController(IUserService userService, IStoreService storeService)
        {
            StoreService = storeService;
            UserService= userService;
        }


        [HttpPost("")]
        public async Task<IActionResult> Add([FromBody]StoreDto input)
        {
            var user = await UserService.GetAsyncByUserName(HttpContext.User.Identity.Name);

            var result = await StoreService.Create(input, user);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute]int id)
        {
            var result= await StoreService.GetAsync(id);
            return Ok(result);
        }


        [HttpGet("")]
        public async Task<IActionResult> GetAll( )
        {
            var result = await StoreService.GetList();
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await StoreService.Delete(id);
            return Ok(result);
        }

        [HttpPut("")]
        public async Task<IActionResult> Update(StoreDetail input)
        {
            var result = await StoreService.Update(input);
            return Ok(result);
        }
    }
}
