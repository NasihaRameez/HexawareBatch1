using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementSystem.Entity
{
    //3.
    public class Electronics : Product
    {
        public string Brand { get; set; }
        public int WarrantyPeriod { get; set; }

        public Electronics(int productId, string name, string description, double price, int quantity, string type, string brand, int warrantyPeriod)
    : base(productId, name, description, price, quantity, type)
        {
            this.Brand = brand;
            this.WarrantyPeriod = warrantyPeriod;
        }
       
    }
}

