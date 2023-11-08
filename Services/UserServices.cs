using entities;
using entities.Models;
using Repository;

namespace Services
{
    public class UserServices : IUserServices
    {
        IUserRepository _UserRepository;
        public UserServices(IUserRepository userRepository)
        {
            _UserRepository = userRepository;
        }
        public async Task<User> getUserByUserNameAndPassword(string UserName, string Password)
        {
            return await _UserRepository.getUserByUserNameAndPassword(UserName, Password);
        }

        public async Task<User> addUser(User user)
        {
            //check strength of password
            var result = Zxcvbn.Core.EvaluatePassword(user.Password);
            if (result.Score <= 2) return null;
            return await _UserRepository.addUser(user);
        }

        public async Task<User> updateUser(int id, User userToUpdate)
        {
            return await _UserRepository.updateUser(id, userToUpdate);
        }
    }
}