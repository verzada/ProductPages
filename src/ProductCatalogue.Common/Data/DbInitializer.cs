using System;
using System.Linq;
using ProductPages.Common.Models;

namespace ProductPages.Common.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ProductPageContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            CreateProductPageTypes(context);
            CreateProductPages(context);
        }

        private static void CreateProductPageTypes(ProductPageContext context)
        {
            if (context.ProductPageTypes == null)
            {
                return;
            }

            if (context.ProductPageTypes.Any())
            {
                return;

            }

            var productPageTypes = new[]
            {
                new ProductPageType {TypeOfProduct = "WebPage"},
                new ProductPageType {TypeOfProduct = "WebApplication"},
                new ProductPageType {TypeOfProduct = "Integration"},
            };

            foreach (var type in productPageTypes)
            {
                context.ProductPageTypes.Add(type);
            }
         
            context.SaveChanges();
        }

        private static void CreateProductPages(ProductPageContext context)
        {
            if (context.ProductPages.Any())
            {
                return; // DB has been seeded
            }

            var loremIpsum = GetLoremIpsum();
            var getTypeOfPage = GetTypeOfPage(context);

            var productPage = new ProductPage
            {
                Created = DateTime.Now,
                CreatedBy = "Test user",
                Description = loremIpsum,
                TypeOfProduct = getTypeOfPage
            };

            context.ProductPages.Add(productPage);
            context.SaveChanges();

        }

        private static ProductPageType GetTypeOfPage(ProductPageContext context)
        {
            var page = context.ProductPageTypes.FirstOrDefault(t => t.TypeOfProduct.Contains("WebPage"));
            return page;
        }

        private static string GetLoremIpsum()
        {
            return
                "<p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras viverra libero dolor, commodo feugiat ex convallis eu. Aenean auctor nibh eleifend diam volutpat, consequat rutrum eros porta. Vestibulum aliquet in leo sed suscipit. Etiam euismod enim non finibus posuere. Sed erat leo, pellentesque nec lorem at, molestie ultricies sem. Nullam et metus diam. Mauris a nib</p>";
        }
       
    }
}
