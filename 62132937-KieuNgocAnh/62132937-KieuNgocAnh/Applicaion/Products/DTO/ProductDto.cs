using _62132937_KieuNgocAnh.Models.Entity;

namespace _62132937_KieuNgocAnh.Aplicaion.Products.DTO
{
    public class ProductDto
    {
        public ProductDto(string name, double price, string image, int categoryId)
        {
            Name = name;
            Price = price;
            Image = image;
            CategoryId = categoryId;
        }

        public string Name { get;  set; }
        public double Price { get;  set; }
        public string Image { get;  set; }
        public int CategoryId { get; set; }
    }
}
