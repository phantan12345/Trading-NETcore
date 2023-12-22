using _62132937_KieuNgocAnh.Aplicaion.Users;
using _62132937_KieuNgocAnh.Applicaion.Stores.DTO;
using _62132937_KieuNgocAnh.Models;
using _62132937_KieuNgocAnh.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace _62132937_KieuNgocAnh.Applicaion.Stores
{
    public class StoreService : IStoreService
    {
        private readonly IUserService UserService;
        private readonly TradingContext context;
        public StoreService(IUserService userService, TradingContext ctx)
        {
            context=ctx;
            UserService=userService;
        }

        public async Task<int> Create(StoreDto input,User_62132937 User)
        {

            var store = new Store_62132937(input.Name,input.Address, User.Id);
            context.Stores.Add(store);
            return await context.SaveChangesAsync();

        }

        public async Task<Store_62132937> Delete(int  id)
        {
            var store = await GetAsync(id);
            store.Delete();
            context.SaveChangesAsync();
            return store;
        }

        public Task<Store_62132937> GetAsync(int id)
        {
            return context.Stores.Where(p =>!p.IsDeleted && p.Id == id).FirstOrDefaultAsync();
        }

        public  Task<Store_62132937> GetAsyncUserId(int id)
        {
            return  context.Stores.Where(p=>!p.IsDeleted && p.UserId == id).FirstOrDefaultAsync();
        }

        public Task<List<Store_62132937>> GetList()
        {
            return context.Stores.Where(p => !p.IsDeleted).ToListAsync();
        }

        public async Task<Store_62132937> Update(StoreDetail input)
        {
            //var user= await UserService.GetItem(input.UserId);
            var store = await GetAsync(input.Id);

            store.Update(input.Name,input.Address,input.IsDeleted);
            return store;
        }
    }
}
