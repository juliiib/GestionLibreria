using GestionLibreria.Application.DTOs;
using GestionLibreria.Domain.Entities;

namespace GestionLibreria.Application.Interfaces
{
    public interface IProductService
    {
        ProductResponse AddProduct(CreateProductRequest request);
        IReadOnlyList<ProductResponse> GetAllProducts();
        ProductResponse? GetProductById(Guid id);
        void RemoveProduct(Guid id);
        bool UpdateProductDetails(Guid id, UpdateProductRequest request);
        bool SetProductAvailability(Guid id, SetAvailabilityRequest request);
    }
}
