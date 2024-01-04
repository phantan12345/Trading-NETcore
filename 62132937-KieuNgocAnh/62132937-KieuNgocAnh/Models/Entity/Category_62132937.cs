using System.ComponentModel.DataAnnotations.Schema;

namespace _62132937_KieuNgocAnh.Models.Entity
{
    [Table("Categorys")]
    public class Category_62132937
    {
        public Category_62132937( )
        {
            Product = new List<Product_62132937>();
        }
        public Category_62132937(string? name)
        {
            Name = name;
            IsDeleted = false;
        }
        public void Delete()
        {
            IsDeleted = true;
        }

        public int Id { get; private set; }
        public string? Name { get; private set; }
        public bool IsDeleted { get; private set; } = false;
        public virtual ICollection<Product_62132937> Product { get; private set; }
    }
}
