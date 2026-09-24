using GestionLibreria.Application.DTOs;
using GestionLibreria.Application.Interfaces;
using GestionLibreria.Domain.Entities;
using GestionLibreria.Domain.Interfaces;

namespace GestionLibreria.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            this._productRepository = productRepository;
        }

        public Product AddProduct(CreateProductRequest request)
        {
            var product = new Product(request.InternalCode, request.Title, request.Description, request.IsAvailable, request.Price, request.Location, request.Category);
            
            _productRepository.AddProduct(product);
            
            return product;
        }

        public IReadOnlyList<Product> GetAllProducts()
        {
            return _productRepository.GetAllProducts();
        }

        public Product? GetProductById(Guid id)
        {
            return _productRepository.GetProductById(id);
        }

        public void RemoveProduct(Guid id)
        {
            var product = _productRepository.GetProductById(id);
            if (product == null)
            {
                return;
            }
            _productRepository.RemoveProduct(product);
        }

        public bool UpdateProductDetails(Guid id, UpdateProductRequest request)
        {
            var product = _productRepository.GetProductById(id);
            
            if (product == null)
            {
                return false;
            }
            
            product.UpdateProductDetails(request.Title, request.Description, request.Price, request.Location, request.Category);
            _productRepository.UpdateProduct(product);
            return true;
        }

        public bool SetProductAvailability(Guid id, SetAvailabilityRequest request)
        {
            var product = _productRepository.GetProductById(id);
            if (product == null)
            {
                return false;
            }
            product.SetAvailability(request.IsAvailable);
            _productRepository.UpdateProduct(product);
            return true;
        }
    }
}
