using System;
using System.Collections.Generic;
using System.Text;

namespace BeautySaloon.Entities
{
    public class Bank
    {
        public int ID { get; set; }
        public virtual ICollection<BankProduct> Storage { get; set; }
    }
}
