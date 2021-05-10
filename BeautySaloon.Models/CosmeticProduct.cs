using System;
using System.Collections.Generic;
using System.Text;

namespace BeautySaloon.Models
{
    public class CosmeticProduct
    {
        public int id { get; set; }
        public string name { get; set; }
        public double price { get; set; }
        public int quantity { get; set; }
        public string type { get; set; }
        public TimeSpan deliveryTime { get; set; }
        public DateTime productionTime { get; set; }
        public string Name { get { return name; } }
        public double Price { get { return price; } }
        public string Type { get { return type; } }
        public int Quantity { get { return quantity; } }
        virtual public int IsNeeded()
        {
            return 0;
        }
        virtual public CosmeticProduct Construct()
        {
            return this;
        }

        public string GetProductType()
        {
            return type;
        }
    }
}
