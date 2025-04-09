using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OrderManagementSystem.Entity
{
    //2.
    public class Product
    {
        private int productId;
        private string productName;
        private string description;
        private double price;
        private int quantityInStock;
        private string type;

        public Product(int productId, string productName, string description, double price, int quantityInStock, string type)
        {
            this.productId = productId;
            this.productName = productName;
            this.description = description;
            this.price = price;
            this.quantityInStock = quantityInStock;
            this.type = type;
        }
        public int ProductId
        {
            get { return productId; }
            set { productId = value; }
        }

        public string ProductName
        {
            get { return productName; }
            set { productName = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public double Price
        {
            get { return price; }
            set { price = value; }
        }

        public int QuantityInStock
        {
            get { return quantityInStock; }
            set { quantityInStock = value; }
        }

        public string Type
        {
            get { return type; }
            set { type = value; }
        }
        public override string ToString()
        {
            return $"--- Product Details ---\n" +
           $"Product ID       : {productId}\n" +
           $"Name             : {productName}\n" +
           $"Description      : {description}\n" +
           $"Price            : Rs.{price:F2}\n" +
           $"Quantity in Stock: {quantityInStock}\n" +
           $"Type             : {type}\n";
        }
    }
}