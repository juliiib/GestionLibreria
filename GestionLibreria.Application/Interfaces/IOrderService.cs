using GestionLibreria.Application.DTOs;
using GestionLibreria.Domain.Entities;

namespace GestionLibreria.Application.Interfaces
{
    public interface IOrderService
    {
        OrderResponse? CreateOrder(CreateOrderRequest request);
        IReadOnlyList<OrderResponse> GetAllOrders();
        OrderResponse? GetOrderById(Guid id);
        bool MarkOrderAsCompleted(Guid id);
        bool MarkOrderAsCancelled(Guid id);
    }
}
