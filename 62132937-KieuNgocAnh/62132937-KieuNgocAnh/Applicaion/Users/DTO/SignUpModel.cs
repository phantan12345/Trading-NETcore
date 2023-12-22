using System.ComponentModel.DataAnnotations;

namespace _62132937_KieuNgocAnh.Aplicaion.Users.DTO
{
    public class SignUpModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public int Role { get; set; }
    }
}
