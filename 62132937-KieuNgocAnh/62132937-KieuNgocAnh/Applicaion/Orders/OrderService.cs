using _62132937_KieuNgocAnh.Aplicaion.Users;
using _62132937_KieuNgocAnh.Models;
using _62132937_KieuNgocAnh.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace _62132937_KieuNgocAnh.Applicaion.Orders
{
    public class OrderService : IOrderService
    {
        private readonly TradingContext Context;
        private readonly IUserService _userService;
        public OrderService(IUserService userService,TradingContext ctx)
        {
            Context = ctx;
            _userService=userService;
        }
        public  async Task<Order_62132937> Create(int userId, string address, string phone)
        {
            var user =  await _userService.GetItem(userId);
            var order = new Order_62132937(user, address,phone);
            Context.Orders.Add(order);
            await Context.SaveChangesAsync();
            order = await Context.Orders.FindAsync(order.Id);

            return order;
        }

        public async Task<Order_62132937> Delete(int id)
        {
            try
            {
                var _origin = await GetAsync(id);
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

        public Task<Order_62132937> GetAsync(int id)
        {
            return Context.Orders.Where(p => !p.IsDeleted && p.Id == id).FirstOrDefaultAsync();
        }
    }
}
