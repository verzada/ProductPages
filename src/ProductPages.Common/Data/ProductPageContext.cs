using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using ProductPages.Common.Models;

namespace ProductPages.Common.Data
{
    public class ProductPageContext : DbContext
    {
        //var builder = new DbContextOptionsBuilder<ApiContext>();
        //builder.UseSqlServer(
        //    "Server=(localdb)\\mssqllocaldb;Database=config;Trusted_Connection=True;MultipleActiveResultSets=true");
 
        //return new ApiContext(builder.Options);

        public ProductPageContext()
        {

        }

        public ProductPageContext(DbContextOptions<ProductPageContext> options) : base(options)
        {

        }

        public ProductPageContext Create(DbContextFactoryOptions options)
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json");
            var configBuilder = configuration.Build();
            var sqlString = configBuilder.GetValue<string>(nameof(ProductPageContext));

            var builder = new DbContextOptionsBuilder<ProductPageContext>();
            builder.UseSqlServer(sqlString);


            //services.AddDbContext<ProductPageContext>(options =>
            //    options.UseSqlServer(Configuration.GetConnectionString("ProductPageContext")));

            return new ProductPageContext(builder.Options);
        }

        public DbSet<ProductPage> ProductPages { get; set; }
        public DbSet<ProductPageType> ProductPageTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Define composite key.
            builder.Entity<ProductPage>()
                .HasKey(lc => new { lc.Id});

            builder.Entity<ProductPageType>().HasKey(t => new { t.Id });
        }
    }
}
