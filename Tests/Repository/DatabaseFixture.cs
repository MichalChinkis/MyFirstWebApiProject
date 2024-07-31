using entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Repository
{
    public class DatabaseFixture : IDisposable
    {
        public CookwareShopContext Context { get; private set; }

        public DatabaseFixture(IConfiguration _configuration)
        {
            // Set up the test database connection and initialize the context
            var options = new DbContextOptionsBuilder<CookwareShopContext>()
                .UseSqlServer("Server=DESKTOP-T7J3RR5\\SQLEXPRESS;Database=Tests;Trusted_Connection=True;")
                .Options;
            Context = new CookwareShopContext(options, _configuration);
            Context.Database.EnsureCreated();// create the data base
        }

        public void Dispose()
        {
            // Clean up the test database after all tests are completed
            Context.Database.EnsureDeleted();
            Context.Dispose();
        }
    }
}
