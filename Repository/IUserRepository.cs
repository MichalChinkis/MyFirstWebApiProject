using entities;

namespace Repository
{
    public interface IUserRepository
    {
        UserClass addUser(UserClass user);
        Task<UserClass> getUserByUserNameAndPassword(global::System.String UserName, global::System.String Password);
        Task<UserClass> updateUser(global::System.Int32 id, UserClass userToUpdate);
    }
}