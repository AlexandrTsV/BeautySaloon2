using System;
using System.Collections.Generic;
using System.Text;

namespace BeautySaloon.Entities
{
    public class CosmeticProduct
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public TimeSpan DeliveryTime { get; set; }
        public DateTime ProductionTime { get; set; }
        public int MinimalQuantity { get; set; }
#nullable enable
        public TimeSpan? StorageTime { get; set; }
#nullable disable
        public int ProductTypeID { get; set; }
        public virtual ProductType Type { get; set; }
        public int ServiceID { get; set; }
        public virtual Service Service { get; set; }
    }
}
