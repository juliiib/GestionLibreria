using GestionLibreria.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionLibreria.Application.DTOs
{
    public record UpdateProductRequest(string Title, string Description, decimal Price, string Location, Product.ProductCategoryEnum Category);
}
