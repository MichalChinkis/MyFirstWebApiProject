using entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Core.Infrastructure;
using Services;
using System.Reflection.Metadata;
using System.Text.Json;
using Zxcvbn;
using entities.Models;



// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyFirstWebApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
      
        IUserServices userServices;
        public UsersController(IUserServices _userServices) {
            userServices = _userServices;
        }

        // GET: api/<UsersController>
        [HttpGet]
        public async Task<IEnumerable<User>> Get() { 
            return await userServices.getUsers();
        }

    // GET api/<UsersController>/5
    [HttpGet("{id}")]
        public async Task<User> getUserById(int id)
        { 
            return await userServices.getUserById(id);
        }


        // POST api/<UsersController>
        [HttpPost]
        public async Task<User> Post([FromBody] User user)
        {
            User theAddUser= await userServices.addUser(user);
            return theAddUser;
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] User userToUpdate)
        {
             await userServices.updateUser(id, userToUpdate);
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await userServices.DeleteUser(id);
           
        }
    }
}
