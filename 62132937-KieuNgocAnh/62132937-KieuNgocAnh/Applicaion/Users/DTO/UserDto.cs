using _62132937_KieuNgocAnh.Models.Entity;

namespace _62132937_KieuNgocAnh.Aplicaion.Users.DTO
{
    public class UserDto
    {
        public int Id { get;  set; }
        public string Name { get;  set; }
        public string UserName { get;  set; }
        public string Password { get;  set; }
        public bool? IsDeleted { get;  set; } = false;
        public int RoleId { get;  set; }
    }
}
