using System.ComponentModel.DataAnnotations.Schema;

namespace _62132937_KieuNgocAnh.Models.Entity
{
    [Table("Users")]
    public class User_62132937
    {
        public User_62132937() { }
        public User_62132937(string name, string userName, string password, int roles)
        {
            Name = name;
            UserName = userName;
            Password = password;
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


    }
}
