using System.ComponentModel.DataAnnotations.Schema;

namespace _62132937_KieuNgocAnh.Models.Entity
{
    [Table("OrderDetail")]
    public class OrderDetail_62132937
    {
        public OrderDetail_62132937()
        {
        }
        public OrderDetail_62132937(int count,  Order_62132937 orderId,Product_62132937 product)
        {
            Count = count;
            Order = orderId;
            Product = product;
        }
        public void Delete()
        {
            IsDeleted = true;
        }

        public int Id { get;private set; }
        public int Count { get; private set; }
        public int ProductId { get; set; }

        public Product_62132937 Product { get; set; }
        public Order_62132937 Order { get; set; }

        public bool IsDeleted { get; private set; } = false;

       
    }
}
