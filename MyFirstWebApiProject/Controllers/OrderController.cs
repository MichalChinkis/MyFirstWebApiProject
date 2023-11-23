using AutoMapper;
using entities.Models;
using Microsoft.AspNetCore.Mvc;
using Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyFirstWebApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        IOrderServices _OrderServices;
        IMapper mapper;
        public OrderController(IOrderServices orderServices, IMapper _mapper)
        {
            _OrderServices = orderServices;
            mapper = _mapper;
        }
        // GET: api/<OrderController>
        [HttpGet]
        public async Task<IEnumerable<Order>> Get()
        {
            return await _OrderServices.getOrders();
        }

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public async Task<Order> getOrderById(int id)
        {
            return await _OrderServices.getOrderById(id);
        }


        // POST api/<OrderController>
        [HttpPost]
        public async Task<Order> Post([FromBody] Order order)
        {
            Order theAddOrder = await _OrderServices.addOrder(order);
            return theAddOrder;
        }

        // PUT api/<OrderController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
