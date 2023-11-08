using entities;
using entities.Models;

namespace Services
{
    public interface IProductsServices
    {
        Task<User> getUserByUserNameAndPassword();
    }
}