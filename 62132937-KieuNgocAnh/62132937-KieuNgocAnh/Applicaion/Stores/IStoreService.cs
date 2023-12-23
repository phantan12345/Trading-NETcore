using _62132937_KieuNgocAnh.Applicaion.Stores.DTO;
using _62132937_KieuNgocAnh.Models.Entity;

namespace _62132937_KieuNgocAnh.Applicaion.Stores
{
    public interface IStoreService
    {
        Task<List<Store_62132937>> GetList( );
        Task<int> Create(StoreDto input, User_62132937 User);
        Task<Store_62132937> Update(StoreDetail input);
        Task<Store_62132937> Delete(int id);
        Task<Store_62132937> GetAsync(int id);
        Task<Store_62132937> GetAsyncUserId(int id);

    }
}
