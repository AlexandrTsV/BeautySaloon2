using System;
using System.Collections.Generic;
using System.Text;

namespace BeautySaloon.Models
{
    public class Saloon
    {
        public int id { get; set; }
        public List<CosmeticProduct> storage { get; set; }
    }
}
