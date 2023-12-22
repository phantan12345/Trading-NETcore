using System.ComponentModel.DataAnnotations.Schema;

namespace _62132937_KieuNgocAnh.Models.Entity
{
    [Table("OrderDetail")]
    public class OrderDetail_62132937
    {
        public OrderDetail_62132937(int count, int prodcutId, int orderId)
        {
            Count = count;
            ProdcutId = prodcutId;
            OrderId = orderId;
        }

        public int Id { get;private set; }
        public int Count { get; private set; }
        public int ProdcutId { get; private set; }
        public int OrderId { get; private set; }

        public bool IsDeleted { get; private set; } = false;

    }
}
