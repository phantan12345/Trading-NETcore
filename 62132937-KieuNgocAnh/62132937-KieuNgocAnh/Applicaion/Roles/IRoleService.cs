using _62132937_KieuNgocAnh.Aplicaion.Products.DTO;
using _62132937_KieuNgocAnh.Applicaion.Roles.DTO;
using _62132937_KieuNgocAnh.Models.Entity;

namespace _62132937_KieuNgocAnh.Applicaion.Roles
{
    public interface IRoleService
    {
        Task<Role_62132937> GetAsync(int id);
        Task<List<Role_62132937>> GetAllAsync();
        Task<int> Add(RoleDto  input);
    }
}
