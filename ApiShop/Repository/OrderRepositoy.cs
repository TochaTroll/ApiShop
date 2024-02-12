using ApiShop.Context;
using ApiShop.Interfaces;
using ApiShop.Model;
using Microsoft.EntityFrameworkCore;

namespace ApiShop.Repository
{
    public class OrderRepositoy : IOrderRepository
    {
        private readonly ShopContext _shopContext;
        public OrderRepositoy(ShopContext context)
        {
            _shopContext = context;
        }

        public async Task<ICollection<Order>> GetOrders()
        {
            return await _shopContext.Orders.Include(o=> o.OrderPickupPointNavigation).ToListAsync();
        }

        public async Task<ICollection<Order>> GetOrdersByDate(DateTime dateTime)
        {
            return await _shopContext.Orders.Where(o=> o.OrderDate == dateTime).ToListAsync();
        }

        public async Task<ICollection<Order>> GetOrdersByName(string name)
        {
            return await _shopContext.Orders.Include(o => o.OrderPickupPointNavigation).Where(o => EF.Functions.Like(o.FullNameClient, $"%{name}%")).ToListAsync();
        }
    }
}
