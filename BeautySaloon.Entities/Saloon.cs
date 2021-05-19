using System;
using System.Collections.Generic;
using System.Text;

namespace BeautySaloon.Entities
{
    public class Saloon
    {
        public int ID { get; set; }
        public virtual ICollection<SaloonProduct> Storage { get; set; }
    }
}
