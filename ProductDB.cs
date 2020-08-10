using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCRUDApp
{
    static class ProductDB
    {
        public static List<Product> GetAllProducts()
        {
            using (ProductContext context = new ProductContext())
            {
                // Query syntax
                List<Product> allPods =
                    (from prod in context.Products
                     select prod).ToList();

                // Method syntax
                List<Product> allProds2 =
                    context.Products.ToList();

                return allPods;
            }
        }

        /// <summary>
        /// Adds a product to the database. Returns the product
        /// with the <see cref="Product.ProductId" /> (Identity column) populated
        /// </summary>
        /// <param name="p">The product to be added</param>
        /// <returns></returns>
        public static Product Add(Product p)
        {
            using (ProductContext context = new ProductContext())
            {
                context.Products.Add(p); // Prepares Insert Query
                context.SaveChanges(); // Executes all pending insert/update/delete queries

                return p;
            }
        }

        public static Product Update(Product p)
        {
            using (var context = new ProductContext())
            {
                context.Database.Log = Console.WriteLine;

                // prepare update query for product
                context.Entry(p).State = EntityState.Modified;

                context.SaveChanges();

                return p;
            }
        }

        public static void Delete(Product p)
        {

            // try then finnaly except its using instead
            // also calls dispose at the end
            using (ProductContext context = new ProductContext())
            {
                // Write EF output to the console
                context.Database.Log = Console.WriteLine;

                // Telling EF that the product is already in the DB
                // and it should be deleted
                context.Entry(p).State = EntityState.Deleted;

                // Executes Delete query
                context.SaveChanges();
            }
        }

        public static void Delete(int Id)
        {
            using (var context = new ProductContext())
            {
                // Get product to delete from database

                // Query syntax
                Product prodToDelete =
                    (from p in context.Products
                     where p.ProductId == Id
                     select p).Single();

                // Method syntax
                Product prodToDelete2 =
                    context.Products
                           .Where(p => p.ProductId == Id)
                           .Single();

                //private bool Filter(Product p, int id)
                //{
                //    return p.ProductId == Id
                //}


                context.Entry(prodToDelete).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

    }
}
