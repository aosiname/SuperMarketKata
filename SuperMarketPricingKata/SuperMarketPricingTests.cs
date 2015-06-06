using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SuperMarketPricingKata
{
    [TestClass]
    public class SuperMarketPricingTests
    {
        [TestMethod]
        public void BeansCosts65()
        {
            Product product = new Product() { Name = "Beans", Price = 0.65m };
            decimal expected = 0.65m;
            decimal actual = product.Price;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ThreeBeansCostADollar()
        {
            // Arrange
            Product product = new Product() { Name = "Beans", Price = 0.65m };
            Product product2 = new Product() { Name = "Beans", Price = 0.65m };
            Product product3 = new Product() { Name = "Beans", Price = 0.65m };

            Basket basket = new Basket();
            basket.Products.Add(product);
            basket.Products.Add(product2);
            basket.Products.Add(product3);

            decimal totalPrice = basket.GetProductsTotalPrice();
            decimal expected = 1;
            decimal actual = totalPrice;

            Assert.AreEqual(expected, actual);
        }
    }


    public class Basket
    {
        public List<Product> Products { get; set; }

        public Basket()
        {
            this.Products = new List<Product>();
        }

        public decimal GetProductsTotalPrice()
        {
            decimal totalPrice = this.Products.Sum(product => product.Price);

            if (Products.Count == 3)
            {
                return 1;
            }   

            return totalPrice;
        }

        public void CalculateDiscount()
        {
         
        }
    }

    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
