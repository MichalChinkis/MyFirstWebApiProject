using entities.Models;
using Microsoft.AspNetCore.Mvc;
using Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyFirstWebApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        ICategoryServices _CategoryServices;
        public CategoryController(ICategoryServices categoryServices)
        {
            _CategoryServices = categoryServices;
        }
        // GET: api/<Category>
        [HttpGet]
        public async Task<IEnumerable<Category>> Get()
        {
            return await _CategoryServices.getCategories();
        }

        // GET api/<Category>/5
        [HttpGet("{id}")]
        public async Task<Category> getUserById(int id)
        {
            return await _CategoryServices.getCategoryById(id);
        }

        // POST api/<Category>
        [HttpPost]
        public async Task<Category> Post([FromBody] Category category)
        {
            Category theAddCategory = await _CategoryServices.addCategory(category);
            return theAddCategory;
        }

        // PUT api/<Category>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<Category>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
