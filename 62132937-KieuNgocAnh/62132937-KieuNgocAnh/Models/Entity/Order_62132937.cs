using System.ComponentModel.DataAnnotations.Schema;

namespace _62132937_KieuNgocAnh.Models.Entity
{
    [Table("Orders")]
    public class Order_62132937
    {
        public Order_62132937( int userId)
        {
            CreateDate = DateTime.Now;
            UserId = userId;
        }

        public int Id { get;private set; }
        public DateTime CreateDate { get; private set; }
        public int UserId { get; private set; }
        public bool? IsDeleted { get; private set; } = false;

    }
}
