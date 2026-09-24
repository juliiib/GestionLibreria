using GestionLibreria.Application.DTOs;
using GestionLibreria.Application.Interfaces;
using GestionLibreria.Domain.Entities;
using GestionLibreria.Domain.Interfaces;

namespace GestionLibreria.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            this._orderRepository = orderRepository;
        }

        public Order? CreateOrder(CreateOrderRequest request)
        {
            
            var order = new Order(request.ClientId, request.EmployeeId);

            foreach (var detail in request.OrderDetails)
            {
                order.AddOrderDetail(detail.ProductId, detail.Quantity, detail.UnitPrice);
            }

            _orderRepository.AddOrder(order);
            
            return order;
        }

        public IReadOnlyList<Order> GetAllOrders()
        {
            return _orderRepository.GetAllOrders();
        }

        public Order? GetOrderById(Guid id)
        {
            return _orderRepository.GetOrderById(id);
        }

        public bool MarkOrderAsCompleted(Guid id)
        {
            var order = _orderRepository.GetOrderById(id);
            if (order == null || order.Status != Order.OrderStatusEnum.Pending)
            {
                return false;
            }
            order.MarkAsPaid();
            _orderRepository.UpdateOrder(order);
            return true;
        }

        public bool MarkOrderAsCancelled(Guid id)
        {
            var order = _orderRepository.GetOrderById(id);
            if (order == null || order.Status != Order.OrderStatusEnum.Pending)
            {
                return false;
            }
            order.CancelOrder();
            _orderRepository.UpdateOrder(order);
            return true;
        }

    }
}
