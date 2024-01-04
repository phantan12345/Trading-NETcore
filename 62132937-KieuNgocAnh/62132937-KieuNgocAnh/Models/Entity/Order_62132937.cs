using System.ComponentModel.DataAnnotations.Schema;

namespace _62132937_KieuNgocAnh.Models.Entity
{
    [Table("Orders")]
    public class Order_62132937
    {
        public Order_62132937()
        {
            OrderDetail = new List<OrderDetail_62132937>();
        }
        public Order_62132937(  User_62132937 userId,string address, string phone)
        {
            Address = address;
            Phone = phone;
            CreateDate = DateTime.Now;
            User = userId;
        }

        public void Delete()
        {
            IsDeleted = true;
        }

        public int Id { get;private set; }
        public string Address { get; private set; }
        public string Phone { get; private set; }
        public DateTime CreateDate { get; private set; }
        public User_62132937 User { get; private set; }
        public ICollection<OrderDetail_62132937> OrderDetail { get; set; }
        public bool IsDeleted { get; private set; } = false;

    }
}
