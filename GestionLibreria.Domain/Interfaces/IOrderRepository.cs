using GestionLibreria.Domain.Entities;

namespace GestionLibreria.Domain.Interfaces
{
    public interface IOrderRepository
    {
        void AddOrder(Order order);
        IReadOnlyList<Order> GetAllOrders();
        Order? GetOrderById(Guid id);
        void UpdateOrder(Order order);

    }
}
