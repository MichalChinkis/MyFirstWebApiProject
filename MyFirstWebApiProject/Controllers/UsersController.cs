using entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Core.Infrastructure;
using Services;
using System.Reflection.Metadata;
using System.Text.Json;
using Zxcvbn;
using entities.Models;
using AutoMapper;
using DTO;



// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyFirstWebApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        
        IUserServices userServices;
        IMapper mapper;
        public UsersController(IUserServices _userServices, IMapper _mapper) {
            userServices = _userServices;
            mapper = _mapper;
        }

        // GET: api/<UsersController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsersDTO>>> GetUsers() { 
            IEnumerable<User> users = await userServices.getUsers();
            IEnumerable<UsersDTO> usersDTO = mapper.Map<IEnumerable<User>, IEnumerable<UsersDTO>>(users);
            return Ok(usersDTO);
        }

        [Route("login")]
        [HttpPost]
        public async Task<ActionResult> get([FromBody] userLoginDTO userLoginDTO)
        {
            User userExsist = await userServices.getUserByUserNameAndPassword(userLoginDTO.UserName, userLoginDTO.Password);
            if (userExsist == null) { 
                return NoContent();
            }
            return Ok(userExsist);
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public async Task<UsersDTO> getUserById(int id)
        {
            User user = await userServices.getUserById(id);
            UsersDTO userDTO = mapper.Map<User, UsersDTO>(user);
            return userDTO;
        }


        // POST api/<UsersController>
        [HttpPost]
        public async Task<UsersDTO> Post([FromBody] User user)
        {
            User theAddUser= await userServices.addUser(user);
            UsersDTO userDTO = mapper.Map<User, UsersDTO>(user);
            return userDTO;
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
