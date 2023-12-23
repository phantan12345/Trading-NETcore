using _62132937_KieuNgocAnh.Models.Entity;

namespace _62132937_KieuNgocAnh.Applicaion.Orders.DTO
{
    public class OrderDto
    {
        public DateTime CreateDate { get; private set; }
        public int UserId { get; private set; }
        public User_62132937 Users { get; private set; }
        public bool? IsDeleted { get; private set; } = false;
    }
}
