using System;
using System.Collections.Generic;
using System.Text;

namespace GestionLibreria.Application.DTOs
{
    public record CreateOrderRequest(Guid ClientId, Guid EmployeeId, List<CreateOrderDetailRequest> OrderDetails);
}
