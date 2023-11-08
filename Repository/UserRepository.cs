using entities;
using System.Text.Json;
using entities.Models;

namespace Repository;

public class UserRepository: IUserRepository
{
    private readonly CookwareShopContext _CookwareShopContext;
    public UserRepository(CookwareShopContext cookwareShopContext)
    {
        _CookwareShopContext = cookwareShopContext;
    }
    public async Task<User> addUser(User user)
    {
      await _CookwareShopContext.Users.AddAsync(user);
       await _CookwareShopContext.SaveChangesAsync();
        return user;
    }

    public Task<User> getUserByUserNameAndPassword(string UserName, string Password)
    {
        throw new NotImplementedException();
    }

    public Task<User> updateUser(int id, User userToUpdate)
    {
        throw new NotImplementedException();
    }
}