using System;
using System.Collections.Generic;
using System.Text;

namespace BeautySaloon.Entities
{
    public class SaloonProduct
    {
        public int id { get; set; }
        public int saloonId { get; set; }
        public int productId { get; set; }
    }
}
