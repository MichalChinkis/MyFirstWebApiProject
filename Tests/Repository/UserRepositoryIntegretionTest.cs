using entities.Models;
using Repository;
using Xunit;

namespace Tests.Repository
{
    public class UserRepositoryIntegretionTest : IClassFixture<DatabaseFixture>
    {
        private readonly CookwareShopContext _dbContext;
        private readonly UserRepository _userRepository;

        public UserRepositoryIntegretionTest(DatabaseFixture databaseFixture)
        {
            _dbContext = databaseFixture.Context;
            _userRepository = new UserRepository(_dbContext);
        }

        [Fact]
        public async Task GetUser_ValidCredentials_ReturnsUser()
        {
            var userName = "mc";
            var password = "m123";
            var user = new User { UserName = userName, Password = password, FirstName = "michal", LastName = "chinkis" };

            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            var result = await _userRepository.getUserByUserNameAndPassword(userName, password);

            Assert.NotNull(result);
        }
      
    }
}
