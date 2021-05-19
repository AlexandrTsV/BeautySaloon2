using System;
using System.Collections.Generic;
using System.Text;

namespace BeautySaloon.Entities
{
    public class SaloonProduct
    {
        public int ID { get; set; }
        public int SaloonID { get; set; }
        public int CosmeticProductID { get; set; }
        public virtual Saloon Saloon { get; set; }
        public virtual CosmeticProduct CosmeticProduct { get; set; }
    }
}
