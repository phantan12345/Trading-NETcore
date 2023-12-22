using _62132937_KieuNgocAnh.Applicaion.Categorys.DTO;
using _62132937_KieuNgocAnh.Models.Entity;

namespace _62132937_KieuNgocAnh.Applicaion.Categorys
{
    public interface ICategoryService
    {
        Task<Category_62132937> GetAsync(int id);
        Task<List<Category_62132937>> GetAllAsync();
        Task<int> Add(CategoryDto input);

    }
}
