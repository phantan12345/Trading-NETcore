using _62132937_KieuNgocAnh.Aplicaion.Users.DTO;
using _62132937_KieuNgocAnh.Models.Entity;
using Microsoft.AspNetCore.Identity;

namespace _62132937_KieuNgocAnh.Aplicaion.Users
{
    public interface IUserService
    {
        Task<User_62132937> GetAsyncByUserName(string UserName);
        Task<bool> ValidateUser(string UserName, string PassWord);
        Task<int> Create(SignUpModel model);
        Task<List<User_62132937>> GetList();
        Task<User_62132937> GetItem(int id);
        public Task<User_62132937> Update(UserDto origin);
        Task<string> Authenticate(string login, string pwd);
        void Delete(int id);


    }
}
