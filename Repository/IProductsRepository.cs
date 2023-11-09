using entities;
using entities.Models;

namespace Repository
{
    public interface IProductsRepository
    {
    
        Task<Product> addProduct(Product product);
        Task<IEnumerable<Product>> getProducts();

        Task<Product> getProductById(int id);
    }
}