using GestionLibreria.Domain.Entities;

namespace GestionLibreria.Domain.Interfaces
{
    public interface IProductRepository
    {
        void AddProduct(Product product);
        IReadOnlyList<Product> GetAllProducts();
        Product? GetProductById(Guid id);
        void RemoveProduct(Product product);
        void UpdateProduct(Product product);

    }
}
