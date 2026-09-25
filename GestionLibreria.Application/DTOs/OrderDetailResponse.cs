using GestionLibreria.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionLibreria.Application.DTOs
{
    public record OrderDetailResponse(
        Guid ProductId,
        int Quantity,
        decimal UnitPrice)
    {
        public static OrderDetailResponse FromOrderDetail(OrderDetail orderDetail)
        {
            return new OrderDetailResponse(
                orderDetail.ProductId,
                orderDetail.Quantity,
                orderDetail.UnitPrice
            );
        }
    }
}
