using ApiShop.Context;
using ApiShop.Interfaces;
using ApiShop.Model;
using Microsoft.EntityFrameworkCore;

namespace ApiShop.Repository
{
    public class UserRepository : IUserRepository
    {
        private ShopContext _shopContext;

        public UserRepository(ShopContext context)
        {
            _shopContext = context;
        }
   
        public async Task<ICollection<User>> GetUsers()
        {
            return await _shopContext.Users.Include(u=> u.UserRoleNavigation).ToListAsync();
        }

        public async Task<User> GetUser(int userId)
        {        
           return await _shopContext.Users.Include(u=> u.UserRoleNavigation).FirstOrDefaultAsync(u=>u.UserId == userId);
        }

        public async Task<ICollection<User>> GetUsersByRole(string role)
        {
           return await _shopContext.Users.Include(u=> u.UserRoleNavigation).Where(u=> u.UserRoleNavigation.RoleName ==  role).ToListAsync();
        }

        public async Task<bool> CreateUser(User user)
        {
            await _shopContext.Users.AddAsync(user);
            return await SaveUser();
        }

        public async Task<bool> SaveUser()
        {
            var saved = await _shopContext.SaveChangesAsync();
            return saved > 0 ? true : false;         
        }
    }
}
