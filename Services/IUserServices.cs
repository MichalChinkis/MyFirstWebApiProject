using entities;

namespace Services
{
    public interface IUserServices
    {
        UserClass addUser(UserClass user);
        Task<UserClass> getUserByUserNameAndPassword(string UserName, string Password);
        Task<UserClass> updateUser(int id, UserClass userToUpdate);
    }
}