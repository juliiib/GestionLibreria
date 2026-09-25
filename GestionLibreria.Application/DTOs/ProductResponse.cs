using GestionLibreria.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using static GestionLibreria.Domain.Entities.Product;

namespace GestionLibreria.Application.DTOs
{
    public record ProductResponse(
        Guid Id,
        String InternalCode,
        String Title,
        String Description,
        Boolean IsAvailable,
        decimal Price,
        String Location,
        ProductCategoryEnum Category)
    {
        public static ProductResponse FromProduct(Product product)
        {
            return new ProductResponse(
                product.Id,
                product.InternalCode,
                product.Title,
                product.Description,
                product.IsAvailable,
                product.Price,
                product.Location,
                product.Category
            );
        }
    }
}
