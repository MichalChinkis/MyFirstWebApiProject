using AutoMapper;
using entities;
using entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;
using Services;
using DTO;

namespace MyFirstWebApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : Controller
    {
        IProductsServices _ProductsServices;
        IMapper mapper;

        public ProductsController(IProductsServices productsServices, IMapper _mapper)
        {
            _ProductsServices = productsServices;
            mapper = _mapper;
        }
        // GET: ProductsController
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductsDTO>>> GetProducts(string? desc, int? minPrice, int? maxPrice,[FromQuery] int?[] categoryIdys, int position=1, int skip=8)
        {
            IEnumerable<Product> products = await _ProductsServices.getProducts(desc, minPrice, maxPrice, categoryIdys, position, skip);
            IEnumerable<ProductsDTO> productsDTOs = mapper.Map<IEnumerable<Product>,IEnumerable<ProductsDTO>>(products);
            return Ok(productsDTOs);
        }

        [HttpGet("{id}")]
        public async Task<Product> getProductById(int id)
        {
            return await _ProductsServices.getProductById(id);
        }


        // POST api/<UsersController>
        [HttpPost]
        public async Task<ProductsDTO> Post([FromBody] Product product)
        {
            Product theAddProd = await _ProductsServices.addProduct(product);
            ProductsDTO productDTO = mapper.Map<Product, ProductsDTO>(theAddProd);
            return productDTO;
        }
    }
}
