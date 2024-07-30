# MyFirstWebApiProject
About:
Hello and welcome to my first Web-Api project.
My project represents a website of kitchen products.
Upon entering the site, the products for sale will be displayed with the option of filtering by price, category or product description.
You can add products to the cart, and create orders on the orders page.
There is a registration option and a registered user login option.
In the case of an attempt to close an order to a user who has not logged in, the user will automatically be transferred to the login page, log in, and continue with the order.
It is possible to update the user's details at any time.
My project is written in .Net7 version and uses API. based on Rest architecture. 
I ensured password strength using the zxcvbn-core package while registration and update users.
I worked with layers that communicate with each other in DI in order of making my application more encapsulated and flexible.
I used async and await to gain scalability.
my data-base I used is sql server
During the construction of the project I used the DB first method with the help of EF orm.
While building the project, I documented my API requests using swagger.
I modified the DTO layer to avoid circular dependencies and mapped the objects using the AutoMapper packages.
I made sure to use configuration files to change information effectively, and write to logging as well as send an email in case of an error.

How to use:
To run the project, you must work with visual studio 2022 or newer.
the DB is sql server.
for creating DB, you can use the code first abilities as follows:
Open your package manager console, 
and type: add-migration [YourDataBaseName] and then type: Update-DataBase. and that's all!

Middlewares: 
I wrote 2 custom middlewares for the project.
one called "rating middleware" that puts each request details in the DB, and another called "errorHandling middleware" which is in charge on error handling, as is written beneath. 

Validation and error handling:
I used entity validation.
The errors are written to the log, and the user gets just an internal error.
Moq.EntityFrameworkCore
using entities.Models;
using Moq;
using Repository;
namespace Tests.Repository;

[TestClass]
public class UserRepositoryUnitTest
{
    [Fact]
    public async Task GetUser_ValidCredentials_ReturnsUser()
    {
        var user = new User { Email = "", Password = "" };

        var mockContext = new Mock<CookwareShopContext>();
        var users = new List<User>() { user };
        mockContext.Setup(x => x.Users).ReturnsDbSet(users);

        var userRepository = new UserRepository(mockContext.Object);
        var result = await userRepository.getUserByUserNameAndPassword(user.Email, user.Password);

        Assert.Equals(user, result);
    }
}
