using _62132937_KieuNgocAnh.Models;
using _62132937_KieuNgocAnh.Models.Entity;
using Microsoft.EntityFrameworkCore;

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



        public async Task<OrderDetail_62132937> Delete(int id)
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

        public  Task<OrderDetail_62132937> GetAsync(int id)
        {
            return  Context.Orderdetails.Where(p=>!p.IsDeleted && p.Id==id).FirstOrDefaultAsync();
        }
    }
}
