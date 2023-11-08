using entities;
using entities.Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ProductsServices 
        //: IProductsServices
    {
        IProductsRepository _ProductsRepository;
        public ProductsServices(IProductsRepository productsRepository)
        {
            _ProductsRepository = productsRepository;
        }
        public async Task<User> getUserByUserNameAndPassword()
        {
            return await _ProductsRepository.getAllProducts();
        }
    }
}
