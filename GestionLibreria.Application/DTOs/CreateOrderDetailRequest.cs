using System;
using System.Collections.Generic;
using System.Text;

namespace GestionLibreria.Application.DTOs
{
    public record CreateOrderDetailRequest(Guid ProductId, int Quantity, decimal UnitPrice);
}
