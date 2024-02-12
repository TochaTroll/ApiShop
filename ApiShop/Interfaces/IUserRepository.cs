using ApiShop.Model;

namespace ApiShop.Interfaces
{
    public interface IUserRepository
    {
        Task<ICollection<User>> GetUsers();
        Task<User> GetUser(int userId);
        Task<ICollection<User>> GetUsersByRole(string role);
        Task<bool> CreateUser(User user);
        Task<bool> SaveUser();


    }
}
