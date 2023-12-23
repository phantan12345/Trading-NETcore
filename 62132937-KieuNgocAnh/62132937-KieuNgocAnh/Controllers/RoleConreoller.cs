using _62132937_KieuNgocAnh.Aplicaion.Products.DTO;
using _62132937_KieuNgocAnh.Aplicaion.Products;
using Microsoft.AspNetCore.Mvc;
using _62132937_KieuNgocAnh.Applicaion.Roles;
using _62132937_KieuNgocAnh.Applicaion.Roles.DTO;

namespace _62132937_KieuNgocAnh.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleConreoller:ControllerBase
    {
        private readonly IRoleService RoleService;

        public RoleConreoller(IRoleService roleService)
        {
            RoleService = roleService;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {
            var result = await RoleService.GetAllAsync();
            return Ok(result);
        }

        [HttpPost("")]
        public async Task<IActionResult> Post([FromBody] RoleDto input)
        {
            var result = await RoleService.Add(input);
            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetAll(int id)
        {
            var result = await RoleService.GetAsync(id);
            return Ok(result);
        }
    }
}
