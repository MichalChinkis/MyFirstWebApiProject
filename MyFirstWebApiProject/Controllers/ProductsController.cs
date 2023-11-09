using entities;
using entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;
using Services;

namespace MyFirstWebApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : Controller
    {
        IProductsServices _ProductsServices;
        public ProductsController(IProductsServices productsServices)
        {
            _ProductsServices = productsServices;
        }
        // GET: ProductsController
        [HttpGet]
        public async Task<IEnumerable<Product>> Get()
        {
                return await _ProductsServices.getProducts();
        }

        [HttpGet("{id}")]
        public async Task<Product> getProductById(int id)
        {
            return await _ProductsServices.getProductById(id);
        }


        // POST api/<UsersController>
        [HttpPost]
        public async Task<Product> Post([FromBody] Product product)
        {
            Product theAddProd = await _ProductsServices.addProduct(product);
            return theAddProd;
        }

        // GET: ProductsController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: ProductsController/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        // POST: ProductsController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        // GET: ProductsController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: ProductsController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        // GET: ProductsController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        // POST: ProductsController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
