using System.ComponentModel.DataAnnotations.Schema;

namespace _62132937_KieuNgocAnh.Models.Entity
{
    [Table("Stores")]
    public class Store_62132937
    {
        public Store_62132937() { }
        public Store_62132937(string name, string address , int userId )
        {
            Name = name;
            Address = address;
            IsDeleted = false;
            UserId = userId;
        }

        public void Update(string name, string address, bool isDeleted  )
        {
            Name = name;
            Address = address;
            IsDeleted = isDeleted;
        }
        public void Delete()
        {
            IsDeleted = true;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Address { get; private set; }
        public bool IsDeleted { get; private set; } = false;
        public int UserId { get; private set; }
       

    }
}
