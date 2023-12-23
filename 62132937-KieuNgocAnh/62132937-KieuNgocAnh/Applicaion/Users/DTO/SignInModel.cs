using System.ComponentModel.DataAnnotations;

namespace _62132937_KieuNgocAnh.Aplicaion.Users.DTO
{
    public class SignInModel
    {
        [Required]
        public string Username { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
    }
}
