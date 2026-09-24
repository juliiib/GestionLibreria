using GestionLibreria.Application.DTOs;
using GestionLibreria.Domain.Entities;

namespace GestionLibreria.Application.Interfaces
{
    public interface IOrderService
    {
        Order? CreateOrder(CreateOrderRequest request);
        IReadOnlyList<Order> GetAllOrders();
        Order? GetOrderById(Guid id);
        bool MarkOrderAsCompleted(Guid id);
        bool MarkOrderAsCancelled(Guid id);
    }
}
