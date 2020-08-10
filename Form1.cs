using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityFrameworkCRUDApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Product p = new Product()
            //{
            //    Title = "Gadget",
            //    Price = 9.99
            //};

            //ProductContext dbContext = new ProductContext();
            //dbContext.Products.Add(p);
            //dbContext.SaveChanges();
            //MessageBox.Show("Added");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var p1 = new Product()
            {
                Title = "Widget",
                Price = 5.99
            };

            ProductDB.Add(p1);

            var p2 = new Product()
            {
                Title = "Gaming chair",
                Price = 299
            };

            ProductDB.Add(p2);

            p1.Price = 15.50;

            ProductDB.Update(p1);

            List<Product> prods = ProductDB.GetAllProducts();

            ProductDB.Delete(p1);
            ProductDB.Delete(p2);

            prods = ProductDB.GetAllProducts();
        }
    }
}
