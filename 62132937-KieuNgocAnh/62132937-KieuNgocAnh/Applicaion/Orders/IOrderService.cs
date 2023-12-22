using _62132937_KieuNgocAnh.Models.Entity;

namespace _62132937_KieuNgocAnh.Applicaion.Orders
{
    public interface IOrderService
    {
        Task<Order_62132937> Create(int userId);
        Task<Order_62132937> Delete(int id);
        Task<Order_62132937> GetAsync(int id);

    }
}
