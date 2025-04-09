using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementSystem.Entity
{ 
    //4.
    public class Clothing : Product
    {
        public string Size { get; set; }
        public string Color { get; set; }

        public Clothing(int productId, string name, string description, double price, int quantity, string type, string size, string color)
    : base(productId, name, description, price, quantity, type)
        {
            this.Size = size;
            this.Color = color;
        }
    }
}