using entities;
using entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Repository
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly CookwareShopContext _CookwareShopContext;
        public ProductsRepository(CookwareShopContext cookwareShopContext)
        {
            _CookwareShopContext = cookwareShopContext;
        }
        public async Task<Product> addProduct(Product product)
        {
            await _CookwareShopContext.Products.AddAsync(product);
            await _CookwareShopContext.SaveChangesAsync();
            return product;
        }

        public async Task<Product> getProductById(int id)
        {
            return await _CookwareShopContext.Products.FindAsync(id);

        }

        public async Task<IEnumerable<Product>> getProducts(string? desc, int? minPrice, int? maxPrice, [FromQuery] int?[] categoryIdys, int position = 1, int skip = 8)
        {
            return await _CookwareShopContext.Products.ToListAsync();

        }
    }
}
