using System;
using System.Collections.Generic;
using System.Text;

namespace BeautySaloon.Entities
{
    public class BankProduct
    {
        public int ID { get; set; }
        public int BankID { get; set; }
        public int CosmeticProductID { get; set; }
        public int Quantity { get; set; }
        public virtual Bank Bank { get; set; }
        public virtual CosmeticProduct CosmeticProduct { get; set; }

    }
}
