using _62132937_KieuNgocAnh.Aplicaion.Products.DTO;
using _62132937_KieuNgocAnh.Applicaion.Categorys;
using _62132937_KieuNgocAnh.Applicaion.Products.DTO;
using _62132937_KieuNgocAnh.Models;
using _62132937_KieuNgocAnh.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace _62132937_KieuNgocAnh.Aplicaion.Products
{
    public class ProductService : IProductService
    {
        private readonly ICategoryService CategoryService;
        private readonly TradingContext context;

        public ProductService( ICategoryService categoryService, TradingContext ctx)
        {
            CategoryService = categoryService;
            context = ctx;
        }
        public  async Task<List<Product_62132937>> GetAllAsync()
        {
            return await context.Products.Where(p => !p.IsDeleted).ToListAsync(); 
        }

        public async Task<Product_62132937> Add(ProductDto input)
        {
            try
            {
                var cate = await CategoryService.GetAsync(input.CategoryId);

                var product = new Product_62132937(input.Name, input.Price,input.Image, cate,input.note);

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

        public async Task<Product_62132937> Delete(int id)
        {
            try
            {
                var _origin = await GetAsync(id);
                if (_origin != null)
                {
                    _origin.Delete();
                }
                context.SaveChanges();
                return _origin;
            }
            catch (Exception ex)
            {
                throw new Exception("Loi: " + ex.Message);
            }
        }

       

        public Task<List<Product_62132937>> Search(SearchParams param)
        {

            if (string.IsNullOrEmpty(param.Kw)&&param.CategoryId==null)
            {
                return context.Products.Where(p => !p.IsDeleted).ToListAsync();

            }
            if (string.IsNullOrEmpty(param.Kw) )
            {
                return context.Products.Where(p => !p.IsDeleted &&p.Category.Id==param.CategoryId).ToListAsync();

            }
            return context.Products.Where(p => !p.IsDeleted && p.Name.Contains(param.Kw)).ToListAsync();

        }
    }
}
