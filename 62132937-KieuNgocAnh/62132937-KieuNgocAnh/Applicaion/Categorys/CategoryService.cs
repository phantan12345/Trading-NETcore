using _62132937_KieuNgocAnh.Applicaion.Categorys.DTO;
using _62132937_KieuNgocAnh.Models;
using _62132937_KieuNgocAnh.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace _62132937_KieuNgocAnh.Applicaion.Categorys
{
    public class CategoryService : ICategoryService
    {

        private readonly TradingContext Context;

        public CategoryService(TradingContext context)
        {
            Context=context;
        }

        public Task<int> Add(CategoryDto input)
        {
            var item = new Category_62132937(input.Name);
            Context.Categorys.Add(item);
            return Context.SaveChangesAsync();
        }

        public async Task<Category_62132937> Delete(int id)
        {
            try
            {
                var _origin =await GetAsync(id);
                if (_origin != null)
                {
                    _origin.Delete();
                }
                Context.SaveChanges();
                return _origin;
            }
            catch (Exception ex)
            {
                throw new Exception("Loi: " + ex.Message);
            }
        }

        public Task<List<Category_62132937>> GetAllAsync()
        {
            return Context.Categorys.Where(p => !p.IsDeleted).ToListAsync();
        }

        public Task<Category_62132937> GetAsync(int id)
        {
            return  Context.Categorys.Where(p => !p.IsDeleted && p.Id == id).FirstOrDefaultAsync();
        }
    }
}
