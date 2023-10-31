using entities;
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
        public async Task<UserClass> getUserByUserNameAndPassword(string UserName, string Password)
        {
            return await _UserRepository.getUserByUserNameAndPassword(UserName, Password);
        }

        public UserClass addUser(UserClass user)
        {
            //check strength of password
            var result = Zxcvbn.Core.EvaluatePassword(user.Password);
            if (result.Score <= 2) return null;
            return _UserRepository.addUser(user);
        }

        public async Task<UserClass> updateUser(int id, UserClass userToUpdate)
        {
            return await _UserRepository.updateUser(id, userToUpdate);
        }
    }
}