namespace _62132937_KieuNgocAnh.Applicaion.OrderDetails
{
    public interface IOrderDetailService
    {
        Task<int> Add(int count, int productId, int orderId);
    }
}
