using System.ComponentModel.DataAnnotations.Schema;

namespace _62132937_KieuNgocAnh.Models.Entity
{
    [Table("Products")]

    public class Product_62132937
    {
        public Product_62132937() { }

        public Product_62132937(string name, double price, string image, int categorys, int stores)
        {
            Name = name;
            Price = price;
            Image = image;
            CategoryId = categorys;
            StoreId = stores;
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

        public int CategoryId { get; set; }

        public int StoreId { get; set; }


    }
}
