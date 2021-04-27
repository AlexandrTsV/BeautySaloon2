using System;
using System.Collections.Generic;
using System.Text;

namespace BeautySaloon.Entities
{
    public class CosmeticProduct
    {
        public CosmeticProduct()
        {
            productionTime = DateTime.Now;
        }
        public int id { get; set; }
        public string name { get; set; }
        public double price { get; set; }
        public int quantity { get; set; }
        public string type { get; set; }

        public TimeSpan deliveryTime { get; set; }
        public DateTime productionTime { get; set; }
    }
}
