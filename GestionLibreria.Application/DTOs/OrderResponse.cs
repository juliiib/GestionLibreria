using GestionLibreria.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using static GestionLibreria.Domain.Entities.Order;

namespace GestionLibreria.Application.DTOs
{
    public record OrderResponse(
        Guid Id,
        OrderStatusEnum Status,
        DateTime CreatedAt,
        DateTime DueDate,
        DateTime PaymentDate,
        decimal TotalAmount,
        Guid ClientId,
        Guid EmployeeId,
        IReadOnlyList<OrderDetailResponse> OrderDetails)
    {
        public static OrderResponse FromOrder(Order order)
        {
            return new OrderResponse(
                order.Id,
                order.Status,
                order.CreatedAt,
                order.DueDate,
                order.PaymentDate,
                order.TotalAmount,
                order.ClientId,
                order.EmployeeId,
                order.OrderDetails.Select(OrderDetails => OrderDetailResponse.FromOrderDetail(OrderDetails)).ToList()
            );
        }
    }
}
