using _62132937_KieuNgocAnh.Aplicaion.Products.DTO;
using _62132937_KieuNgocAnh.Applicaion.Categorys;
using _62132937_KieuNgocAnh.Applicaion.Stores;
using _62132937_KieuNgocAnh.Models;
using _62132937_KieuNgocAnh.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace _62132937_KieuNgocAnh.Aplicaion.Products
{
    public class ProductService : IProductService
    {
        private readonly ICategoryService CategoryService;
        private readonly TradingContext context;
        private readonly IStoreService StoreService;

        public ProductService(IStoreService storeService, ICategoryService categoryService, TradingContext ctx)
        {
            CategoryService = categoryService;
            context = ctx;
            StoreService= storeService;
        }
        public  async Task<List<Product_62132937>> GetAllAsync()
        {
            return await context.Products.Where(p => !p.IsDeleted).ToListAsync(); 
        }

        public async Task<Product_62132937> Add(ProductDto input, User_62132937 user)
        {
            try
            {
                var store = await StoreService.GetAsyncUserId(user.Id);
                var cate = await CategoryService.GetAsync(input.CategoryId);

                var product = new Product_62132937(input.Name, input.Price,input.Image, cate.Id, store.Id);

                context.Products.Add(product);
                context.SaveChanges();
                return product;
            }
            catch (Exception ex)
            {
                throw new Exception("Loi: " + ex.Message);
            }
        }

        public async Task<Product_62132937> GetAsync(int id)
        {
            return await context.Products.Where(p => !p.IsDeleted && p.Id==id).FirstOrDefaultAsync();
        }
    }
}
