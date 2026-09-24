using GestionLibreria.Domain.Entities;

namespace GestionLibreria.Application.DTOs
{
    public record CreateProductRequest(string InternalCode, string Title, string Description, bool IsAvailable, decimal Price, string Location, Product.ProductCategoryEnum Category);
    public record UpdateProductRequest(string Title, string Description, decimal Price, string Location, Product.ProductCategoryEnum Category);
    public record SetAvailabilityRequest(bool IsAvailable);
}

