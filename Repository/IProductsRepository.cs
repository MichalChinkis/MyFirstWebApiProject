using entities;
using entities.Models;

namespace Repository
{
    public interface IProductsRepository
    {
        Task<User> getAllProducts();
    }
}