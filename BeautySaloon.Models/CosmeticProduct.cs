﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BeautySaloon.Models
{
    abstract public class CosmeticProduct
    {
        public int id { get; set; }
        public string name { get; set; }
        public double price { get; set; }
        public int quantity { get; set; }
        public string type { get; set; }
        public TimeSpan deliveryTime { get; set; }
        public DateTime productionTime { get; set; }
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
