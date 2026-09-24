using GestionLibreria.Domain.Entities;
using GestionLibreria.Domain.Interfaces;
using GestionLibreria.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace GestionLibreria.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly GestionLibreriaDbContext _context;

        public OrderRepository(GestionLibreriaDbContext context)
        {
            _context = context;
        }

        public void AddOrder(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
        }
        public IReadOnlyList<Order> GetAllOrders()
        {
            return _context.Orders
                .Include(o => o.OrderDetails)
                .ToList();
        }
        public Order? GetOrderById(Guid id)
        {
            return _context.Orders
                .Include(o => o.OrderDetails)
                .FirstOrDefault(o => o.Id == id);
        }
        public void UpdateOrder(Order order)
        {
            _context.Orders.Update(order);
            _context.SaveChanges();
        }
    }
}
