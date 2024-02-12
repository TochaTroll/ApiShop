using ApiShop.Model;

namespace ApiShop.Interfaces
{
    public interface IOrderRepository
    {
        Task<ICollection<Order>> GetOrders();
        Task<ICollection<Order>> GetOrdersByName(string name);
        Task<ICollection<Order>> GetOrdersByDate(DateTime dateTime);
    }
}
