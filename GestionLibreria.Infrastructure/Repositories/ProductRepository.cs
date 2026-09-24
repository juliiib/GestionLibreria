using GestionLibreria.Domain.Entities;
using GestionLibreria.Domain.Interfaces;
using GestionLibreria.Infrastructure.Persistence;

namespace GestionLibreria.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly GestionLibreriaDbContext _context;
        public ProductRepository(GestionLibreriaDbContext context)
        {
            _context = context;
        }
        public void AddProduct(Product product) => _context.Products.Add(product);
        public IReadOnlyList<Product> GetAllProducts() => _context.Products.ToList();
        public Product? GetProductById(Guid id) => _context.Products.FirstOrDefault(p => p.Id == id);
        public void RemoveProduct(Product product) => _context.Products.Remove(product);
        public void UpdateProduct(Product product) => _context.Products.Update(product);
    }
}
