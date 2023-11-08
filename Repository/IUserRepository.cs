using entities;
using entities.Models;

namespace Repository
{
    public interface IUserRepository
    {
        Task<User> addUser(User user);
        Task<User> getUserByUserNameAndPassword(global::System.String UserName, global::System.String Password);
        Task<User> updateUser(global::System.Int32 id, User userToUpdate);
    }
}