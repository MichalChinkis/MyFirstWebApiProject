using entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Core.Infrastructure;
using Services;
using System.Reflection.Metadata;
using System.Text.Json;
using Zxcvbn;



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
        public async Task<ActionResult> Get([FromQuery]string UserName, [FromQuery]string Password)
        {
            UserClass user = await userServices.getUserByUserNameAndPassword(UserName, Password);
            if (user == null)
                return NoContent();
            return Ok(user);
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
      
        // POST api/<UsersController>
        [HttpPost]
        public ActionResult Post([FromBody] UserClass user)
        {
            try {
                UserClass newUser = userServices.addUser(user);
                return Ok(newUser);
            }
            // return CreatedAtAction(nameof(Get), new { id = user.Id}, user );
            catch (Exception ex) { throw (ex); }
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public async Task<UserClass> Put(int id,[FromBody]UserClass userToUpdate)
        {
            return await userServices.updateUser(id, userToUpdate);
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
