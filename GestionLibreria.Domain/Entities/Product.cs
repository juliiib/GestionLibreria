using System;
using System.Collections.Generic;
using System.Text;

namespace GestionLibreria.Domain.Entities
{
    public class Product
    {
        public enum ProductCategoryEnum { Book, Magazine, Stationery, Other }

        public Guid Id { get; private set; }
        public String InternalCode { get; }
        public String Title { get; private set; }
        public String Description { get; private set; }
        public Boolean IsAvailable { get; private set; }
        public decimal Price { get; private set; }
        public String Location { get; private set; }
        public ProductCategoryEnum Category { get; private set; }

        protected Product() { }

        public Product(string internalCode, string title, string description, bool isAvailable, decimal price, string location, ProductCategoryEnum category)
        {
            if (string.IsNullOrWhiteSpace(internalCode))
            {
                throw new ArgumentException("Internal code cannot be null or empty.", nameof(internalCode));
            }
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentException("Title cannot be null or empty.", nameof(title));
            }
            if (price < 0)
            {
                throw new ArgumentException("Price cannot be negative.", nameof(price));
            }

            Id = Guid.NewGuid();
            InternalCode = internalCode;
            Title = title;
            Description = description;
            IsAvailable = isAvailable;
            Price = price;
            Location = location;
            Category = category;
        }

        public void UpdateProductDetails(string title ,string description, decimal price, string location, ProductCategoryEnum category)
        {
            if (price < 0)
            {
                throw new ArgumentException("Price cannot be negative.", nameof(price));
            }
            Title = title;
            Description = description;
            Price = price;
            Location = location;
            Category = category;
        }

        public void SetAvailability(bool isAvailable)
        {
            IsAvailable = isAvailable;
        }
    }
}
