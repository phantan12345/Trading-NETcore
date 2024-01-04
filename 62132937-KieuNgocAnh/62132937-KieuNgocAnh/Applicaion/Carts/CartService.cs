using _62132937_KieuNgocAnh.Applicaion.OrderDetails;
using _62132937_KieuNgocAnh.Applicaion.Orders;
using _62132937_KieuNgocAnh.Models.Entity;

namespace _62132937_KieuNgocAnh.Applicaion.Carts
{
    public class CartService : ICartService
    {
        private IOrderService OrderService;
        private IOrderDetailService OrderDetailService;

        public CartService(IOrderService orderService, IOrderDetailService orderDetailService)
        {
            OrderService = orderService;
            OrderDetailService= orderDetailService;
        }

      

        public  async Task<Boolean> AddCart(CartDto cartDto,User_62132937 user)
        {
            var orderId= await OrderService.Create(user.Id,cartDto.Address,cartDto.Phone);
            if (orderId == null)
            {
                return false;
            }
            foreach (var item in cartDto.Carts)
            {
                var orderDetail = await OrderDetailService.Add(item.Count, item.Id, orderId.Id);
                if (orderDetail!=0)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
