using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;

namespace _62132937_KieuNgocAnh.Models.Entity
{
    [Table("Users")]
    public class User_62132937
    {
        private static string Salt= "wflvtH41j2TukwrBZqaIbg==";
        public User_62132937()
        {
        }
        public User_62132937(string name, string userName, string password, int roles)
        {
            Name = name;
            UserName = userName;
            Password = HashPassword(password,Salt);
            RolesId = roles;
        }

        public void Update( string name, string userName, string password, int roles)
        {
            Name = name;
            UserName = userName;
            Password = password;
            RolesId = roles;
        }

        public int Id { get;  set; }
        public string  Name { get;  set; }
        public string UserName { get;  set; }
        public string Password { get;  set; }
        public bool IsDeleted { get;  set; } = false;
        public int RolesId { get; set; }  


        public void Delete()
        {
            IsDeleted = true;
        }

        public void SetRoles(int roles)
        {
            RolesId = roles;
        }
        public bool CheckPassword(string password)
        {

            bool isLogin = VerifyPassword(Password, Salt , password);
            if(isLogin)
            {
                return true;
            }
            return false;
        }


        public string GenerateSaltPassword(string password)
        {

            return HashPassword( password, Salt);
       
        }



        public static string GenerateSalt()
        {
            byte[] salt = new byte[16];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            return Convert.ToBase64String(salt);
        }


        // Băm mật khẩu với salt
        public static string HashPassword(string password, string salt)
        {
            byte[] saltBytes = Convert.FromBase64String(salt);
            string hashed = Convert.ToBase64String(
                KeyDerivation.Pbkdf2(
                    password: password,
                    salt: saltBytes,
                    prf: KeyDerivationPrf.HMACSHA256,
                    iterationCount: 10000,
                    numBytesRequested: 256 / 8
                )
            );
            return hashed;
        }


        // Kiểm tra mật khẩu có đúng không
        public static bool VerifyPassword(string hashedPassword, string salt, string passwordToCheck)
        {
            string hashedPasswordToCheck = HashPassword(passwordToCheck, salt);
            return hashedPassword == hashedPasswordToCheck;
        }


    }
}
