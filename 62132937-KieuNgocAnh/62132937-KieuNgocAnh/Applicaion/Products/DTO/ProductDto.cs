using _62132937_KieuNgocAnh.Models.Entity;

namespace _62132937_KieuNgocAnh.Aplicaion.Products.DTO
{
    public class ProductDto
    {
        public ProductDto() { }

        public ProductDto(string name, double price,  int categoryId,string note)
        {
            Name = name;
            Price = price;
            CategoryId = categoryId;
            this.note = note;
        }
        public void SetImage(string path)
        {
            Image = path;
        }

        public string Name { get;  set; }
        public double Price { get;  set; }
        public IFormFile File { get; set; }
        public string Image { get; set; } = "";
        public string note { get; set; }
        public int CategoryId { get; set; }
    }
}
