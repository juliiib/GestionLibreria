using GestionLibreria.Application.DTOs;
using GestionLibreria.Domain.Entities;

namespace GestionLibreria.Application.Interfaces
{
    public interface IProductService
    {
        Product AddProduct(CreateProductRequest request);
        IReadOnlyList<Product> GetAllProducts();
        Product? GetProductById(Guid id);
        void RemoveProduct(Guid id);
        bool UpdateProductDetails(Guid id, UpdateProductRequest request);
        bool SetProductAvailability(Guid id, SetAvailabilityRequest request);
    }
}
