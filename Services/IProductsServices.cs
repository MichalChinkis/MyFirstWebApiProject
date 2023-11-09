using entities;
using entities.Models;

namespace Services
{
    public interface IProductsServices
    {
        Task<Product> addProduct(Product product);
        Task<IEnumerable<Product>> getProducts();
        //Task<User> updateUser(int id, User userToUpdate);

        Task<Product> getProductById(int id);
    }
}