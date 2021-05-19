using System;
using System.Collections.Generic;
using System.Text;

namespace BeautySaloon.Entities
{
    public class ProductType
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int MinimalQuantity { get; set; }
#nullable enable
        public TimeSpan? StorageTime { get; set; }
#nullable disable
    }
}
