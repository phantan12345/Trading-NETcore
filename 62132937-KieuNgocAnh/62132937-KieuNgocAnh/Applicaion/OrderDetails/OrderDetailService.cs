using _62132937_KieuNgocAnh.Aplicaion.Products;
using _62132937_KieuNgocAnh.Applicaion.Orders;
using _62132937_KieuNgocAnh.Models;
using _62132937_KieuNgocAnh.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace _62132937_KieuNgocAnh.Applicaion.OrderDetails
{
    public class OrderDetailService : IOrderDetailService
    {
        private readonly TradingContext Context;
        private readonly IProductService _productService;
        private readonly IOrderService _orderService;
        public OrderDetailService(IOrderService orderService,IProductService productService, TradingContext ctx) {
            Context = ctx;
            _productService=productService;
            _orderService=orderService;
         }
        public async Task<int> Add(int count, int productId, int orderId)
        {
            Product_62132937 prodcut= await _productService.GetAsync(productId);
            Order_62132937 order=await _orderService.GetAsync(orderId);
            var od = new OrderDetail_62132937(count, order, prodcut);
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
