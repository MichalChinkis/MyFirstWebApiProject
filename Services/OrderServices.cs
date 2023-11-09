using entities.Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class OrderServices : IOrderServices
    {

        IOrderRepository _OrderRepository;
        public OrderServices(IOrderRepository orderRepository)
        {
            _OrderRepository = orderRepository;
        }
        public async Task<Order> addOrder(Order order)
        {
            return await _OrderRepository.addOrder(order);
        }

        public async Task<Order> getOrderById(int id)
        {
            return await _OrderRepository.getOrderById(id);
        }

        public async Task<IEnumerable<Order>> getOrders()
        {
            return await _OrderRepository.getOrders();
        }
    }
}
