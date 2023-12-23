using _62132937_KieuNgocAnh.Models.Entity;

namespace _62132937_KieuNgocAnh.Applicaion.Carts
{
    public interface ICartService
    {
        Task<Boolean> AddCart(List<CartDto> cartDto, User_62132937 user);
    }
}
