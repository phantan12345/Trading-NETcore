using _62132937_KieuNgocAnh.Models;
using _62132937_KieuNgocAnh.Models.Entity;

namespace _62132937_KieuNgocAnh.Applicaion.Orders
{
    public class OrderService : IOrderService
    {
        private readonly TradingContext Context;
        public OrderService(TradingContext ctx)
        {
            Context = ctx;
        }
        public  async Task<Order_62132937> Create(int userId)
        {
            var order = new Order_62132937(userId);
            Context.Orders.Add(order);
            await Context.SaveChangesAsync();
            order = await Context.Orders.FindAsync(order.Id);

            return order;
        }
    }
}
