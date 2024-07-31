using Repository;
using entities.Models;
using Moq;
using Moq.EntityFrameworkCore;

namespace Tests.Repository
{
    public class UserRepositoryUnitTest
    {
        [Fact]
        public async Task GetUser_VaildCredentials_ReturnsUser()
        {
            var user = new User { UserName = "mc", Password = "m123"};

            var mockContext = new Mock<CookwareShopContext>();
            var users =  new List<User>() { user };
            mockContext.Setup(x => x.Users).ReturnsDbSet(users);

            var userRepository = new UserRepository(mockContext.Object);

            var result = await userRepository.getUserByUserNameAndPassword(user.UserName, user.Password);

            Assert.Equal(user, result);
        }
    }
}