using System;
using System.Collections.Generic;
using System.Text;

namespace GestionLibreria.Domain.Entities
{
    public class OrderDetail
    {
        public Guid Id { get; }
        public Guid ProductId { get; }
        public int Quantity { get; }
        public decimal UnitPrice { get; }

        protected OrderDetail() { }

        internal OrderDetail(Guid productId, int quantity, decimal unitPrice)
        {
            if (productId == Guid.Empty)
            {
                throw new ArgumentException("Product ID cannot be empty.", nameof(productId));
            }
            if (quantity <= 0)
            {
                throw new ArgumentException("Quantity must be greater than zero.", nameof(quantity));
            }
            if (unitPrice <= 0)
            {
                throw new ArgumentException("Unit price must be greater than zero.", nameof(unitPrice));
            }
            
            Id = Guid.NewGuid();
            ProductId = productId;
            Quantity = quantity;
            UnitPrice = unitPrice;
        }
    }
}
