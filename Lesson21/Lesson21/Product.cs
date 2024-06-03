using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson21
{
    enum ProductCategory
    {
        Food,
        Clothes,
        Gadgets,
        Automotive,
        Furniture,
        Groceries
    }
    internal class Product
    {
        private string productName;
        private ProductCategory category;
        private double price;

        public double Price
        {
            get { return price; } set
            {
                if (value < 0) throw new Exception() ;
                price = value;
            }
        }
        
        public string Id 
        {
            get 
            {
                var r = new Random();
                return (char)((int)'A' + r.Next(26)) + r.Next().ToString() + r.Next().ToString() + r.Next().ToString();
            }
        }

        public string ProductName { 
            get { return productName; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value");
                }
                productName = value;
            }
        }

        public ProductCategory Category
        {
            get { return category; }
            private set { }
        }

        public Product(string name, ProductCategory category, double price)
        {
            productName = name;
            Category = category;
            Price = price;
        }

        public string ToString()
        {
            return $"Name: {productName}\nCategory: {category}\nPrice: {price}\n";
        }



    }
}
