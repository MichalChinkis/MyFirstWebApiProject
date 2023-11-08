using entities;
using entities.Models;

namespace Services
{
    public interface IUserServices
    {
        Task<User> addUser(User user);
        Task<User> getUserByUserNameAndPassword(string UserName, string Password);
        Task<User> updateUser(int id, User userToUpdate);
    }
}