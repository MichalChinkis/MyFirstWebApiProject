using entities.Models;
using Microsoft.AspNetCore.Mvc;
using Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyFirstWebApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemController : ControllerBase
    {
        IOrderItemServices _OrderItemServices;
        public OrderItemController(IOrderItemServices orderItemServices)
        {
            _OrderItemServices = orderItemServices;
        }
        // GET: api/<OrderItemController>
        [HttpGet]
        public async Task<IEnumerable<OrderItem>> Get()
        {
            return await _OrderItemServices.getOrderItems();
        }

        // GET api/<OrderItemController>/5
        [HttpGet("{id}")]
        public async Task<OrderItem> getOrderItemById(int id)
        {
            return await _OrderItemServices.getOrderItemById(id);
        }

        // POST api/<OrderItemController>
        [HttpPost]
        public async Task<OrderItem> Post([FromBody] OrderItem orderItem)
        {
            OrderItem theAddOrderItem = await _OrderItemServices.addOrderItem(orderItem);
            return theAddOrderItem;
        }

        // PUT api/<OrderItemController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<OrderItemController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
