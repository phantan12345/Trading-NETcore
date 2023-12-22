using System.ComponentModel.DataAnnotations.Schema;

namespace _62132937_KieuNgocAnh.Models.Entity
{
    [Table("Roles")]
    public class Role_62132937
    {
        public Role_62132937() { }
        public Role_62132937(string? name)
        {
            Name = name;
        }
        public void Delete()
        {
            IsDeleted = true;
        }

        public int Id { get; private set; }
        public string? Name { get; private set; }
        public bool? IsDeleted { get; private set; } = false;

    }
}
