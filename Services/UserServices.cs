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
        
        public async Task<User> addUser(User user)
        {
            //check strength of password
            var result = Zxcvbn.Core.EvaluatePassword(user.Password);
            if (result.Score <= 2) return null;
            return await _UserRepository.addUser(user);
        }

        public async Task<User> getUserById(int id)
        {
            return await _UserRepository.getUserById(id);
        }

        public async Task<IEnumerable<User>> getUsers()
        {
            return await _UserRepository.getUsers();
        }

        public async Task updateUser(int id, User userToUpdate)
        {
             await _UserRepository.updateUser(id, userToUpdate);
        }

        public async Task DeleteUser(int id)
        { 
            await _UserRepository.DeleteUser(id);
        }
    }
}