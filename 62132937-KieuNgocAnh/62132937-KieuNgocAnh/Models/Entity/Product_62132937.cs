using System.ComponentModel.DataAnnotations.Schema;

namespace _62132937_KieuNgocAnh.Models.Entity
{
    [Table("Products")]

    public class Product_62132937
    {
        public Product_62132937() { }

        public Product_62132937(string name, double price, string image, Category_62132937 categorys,string note )
        {
            Name = name;
            Price = price;
            Image = image;
            Category=categorys;
            this.note=note;
        }
        public void Delete()
        {
            IsDeleted = true;
        }

        public int Id { get; set; }
        public string  Name { get;  set; }
        public double Price { get;  set; }
        public string Image { get;  set; }
        public bool IsDeleted { get;  set; } = false;
        public string note { get; set; }
        public int CategoryId { get; set; }
        public Category_62132937 Category { get; set; }

        public ICollection<OrderDetail_62132937> OrderDetail { get; set; }

    }
}
