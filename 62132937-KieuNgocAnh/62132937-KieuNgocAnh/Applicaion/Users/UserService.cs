using _62132937_KieuNgocAnh.Aplicaion.Users.DTO;
using _62132937_KieuNgocAnh.Applicaion.Roles;
using _62132937_KieuNgocAnh.Models;
using _62132937_KieuNgocAnh.Models.Entity;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace _62132937_KieuNgocAnh.Aplicaion.Users
{
    public class UserService : IUserService
    {
        private readonly IConfiguration _configuration;
        private readonly TradingContext context;
        private readonly IRoleService RoleService;

        public UserService(IRoleService roleService, IConfiguration configuration, TradingContext ctx)
        {
            RoleService= roleService;
            context = ctx;
            _configuration = configuration;

        }

        public void Delete(int originid)
        {
            try
            {
                var _origin = context.Users.FirstOrDefault(x => x.Id == originid);
                if (_origin != null)
                {
                    _origin.Delete();
                }
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Loi: " + ex.Message);
            }
        }

        public async Task<User_62132937> GetAsyncByUserName(string UserName)
        {
            var result= await context.Users.Where(p => p.UserName == UserName && !p.IsDeleted).FirstOrDefaultAsync();
            return result;
        }

  

        public async Task<int> Create(SignUpModel model)
        {
            try
            {

                var role = await RoleService.GetAsync(2);
                
                var user = new User_62132937(model.Name, model.UserName, model.Password, role.Id);


                context.Users.Add(user);
                return await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Loi: " + ex.Message);
            }
        }

        public async Task<List<User_62132937>> GetList()
        {
            var result = await context.Users.Where(p=>!p.IsDeleted ).ToListAsync();
            return result;
        }

        public async Task<User_62132937> GetItem(int id)
        {
            return await context.Users.Where(p => !p.IsDeleted && p.Id==id).FirstOrDefaultAsync();
        }

        public async Task<User_62132937> Update(UserDto origin)
        {
            var user = await GetItem(origin.Id);
            var role=await RoleService.GetAsync(origin.RoleId);
            user.Update(origin.Name, origin.UserName, origin.Password, role.Id);
            return user;
        }


        public async Task<string> Authenticate(string login, string pwd)
        {
            var agent = await GetAsyncByUserName(login);

            var role =await RoleService.GetAsync(agent.RolesId);


            if ( agent.CheckPassword(pwd)==false)
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                new Claim("Id", agent.Id.ToString()),
                new Claim(ClaimTypes.Name, agent.UserName),
                new Claim(ClaimTypes.Role, role.Name),
            }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(key,
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }


     

     


    }
}
