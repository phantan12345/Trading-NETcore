using _62132937_KieuNgocAnh.Models.Entity;

namespace _62132937_KieuNgocAnh.Applicaion.OrderDetails
{
    public interface IOrderDetailService
    {
        Task<int> Add(int count, int productId, int orderId);
        Task<OrderDetail_62132937> Delete(int id);
        Task<OrderDetail_62132937> GetAsync(int id);
    }
}
