using System;
using System.Collections.Generic;
using System.Text;

namespace GestionLibreria.Domain.Entities
{
    public class Order
    {
        public enum OrderStatusEnum { Pending, Paid, Cancelled }
        
        public Guid Id { get; }
        public OrderStatusEnum Status { get; private set; }
        public DateTime CreatedAt { get; }
        public DateTime DueDate { get; }
        public DateTime PaymentDate { get; private set; }
        public decimal TotalAmount { get; private set; }
        public Guid ClientId { get; }
        public Guid EmployeeId { get; }

        private readonly List<OrderDetail> _orderDetails = new List<OrderDetail>();

        public IReadOnlyCollection<OrderDetail> OrderDetails => _orderDetails.AsReadOnly();

        protected Order() { }
        public Order( Guid clientId, Guid employeeId)
        {
            if (clientId == Guid.Empty)
            {
                throw new ArgumentException("Client ID cannot be empty.", nameof(clientId));
            }
            if (employeeId == Guid.Empty)
            {
                throw new ArgumentException("Employee ID cannot be empty.", nameof(employeeId));
            }

            Id = Guid.NewGuid();
            Status = OrderStatusEnum.Pending;
            CreatedAt = DateTime.UtcNow;
            DueDate = DateTime.UtcNow.AddDays(30);
            ClientId = clientId;
            EmployeeId = employeeId;
        }

        public void AddOrderDetail(Guid productId, int quantity, decimal unitPrice)
        {
            if(quantity <= 0)
            {
                throw new ArgumentException("Quantity must be greater than zero.", nameof(quantity));
            }
            if (unitPrice <= 0)
            {
                throw new ArgumentException("Unit price must be greater than zero.", nameof(unitPrice));
            }

            var orderDetail = new OrderDetail(productId, quantity, unitPrice);
            _orderDetails.Add(orderDetail);

            TotalAmount += (quantity * unitPrice);
        }

        public void MarkAsPaid()
        {
            if (Status != OrderStatusEnum.Pending)
            {
                throw new InvalidOperationException("Only pending orders can be marked as paid.");
            }
            Status = OrderStatusEnum.Paid;
            PaymentDate = DateTime.UtcNow;
        }

        public void CancelOrder()
        {
            if (Status != OrderStatusEnum.Pending)
            {
                throw new InvalidOperationException("Only pending orders can be cancelled.");
            }
            Status = OrderStatusEnum.Cancelled;
        }
    }
}
