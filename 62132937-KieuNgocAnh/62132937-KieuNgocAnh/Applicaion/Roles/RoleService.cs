using _62132937_KieuNgocAnh.Applicaion.Roles.DTO;
using _62132937_KieuNgocAnh.Models;
using _62132937_KieuNgocAnh.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace _62132937_KieuNgocAnh.Applicaion.Roles
{
    public class RoleService : IRoleService
    {
        private readonly TradingContext context;
        public RoleService(TradingContext ctx)
        {
            context = ctx;
        }

        public Task<int> Add(RoleDto input)
        {
            var role = new Role_62132937(input.Name);
            context.Roles.Add(role);
            return context.SaveChangesAsync();
        }

        public async Task<Role_62132937> Delete(int id)
        {
            try
            {
                var _origin = await GetAsync(id);
                if (_origin != null)
                {
                    _origin.Delete();
                }
                context.SaveChanges();
                return _origin;
            }
            catch (Exception ex)
            {
                throw new Exception("Loi: " + ex.Message);
            }
        }

        public async Task<List<Role_62132937>> GetAllAsync()
        {
            return await context.Roles.ToListAsync();
        }

        public async Task<Role_62132937> GetAsync(int id)
        {
            var result= await context.Roles.Where(r => r.Id == id).FirstOrDefaultAsync();
            return result;
        }
    }
}
