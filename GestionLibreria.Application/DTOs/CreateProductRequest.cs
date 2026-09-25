using GestionLibreria.Domain.Entities;

namespace GestionLibreria.Application.DTOs
{
    public record CreateProductRequest(string InternalCode, string Title, string Description, bool IsAvailable, decimal Price, string Location, Product.ProductCategoryEnum Category);
}

