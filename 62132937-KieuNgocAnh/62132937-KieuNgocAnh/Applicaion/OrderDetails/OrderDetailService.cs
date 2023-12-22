using _62132937_KieuNgocAnh.Models;
using _62132937_KieuNgocAnh.Models.Entity;

namespace _62132937_KieuNgocAnh.Applicaion.OrderDetails
{
    public class OrderDetailService : IOrderDetailService
    {
        private readonly TradingContext Context;
        public OrderDetailService(TradingContext ctx) {
            Context = ctx;
         }
        public async Task<int> Add(int count, int productId, int orderId)
        {
            var od = new OrderDetail_62132937(count, productId, orderId);
            Context.Orderdetails.Add(od);
            return await Context.SaveChangesAsync();
        }
    }
}
