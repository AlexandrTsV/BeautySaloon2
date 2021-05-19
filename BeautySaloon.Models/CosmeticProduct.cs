using System;
using System.Collections.Generic;
using System.Text;

namespace BeautySaloon.Models
{
    public enum ProductTypes
    {
        Shampoo,
        Gel,
        Balm,
        Pomade,
        Cream
    }

    public class CosmeticProduct
    {
        public int id { get; set; }
        public TimeSpan DeliveryTime { get; set; }
        public DateTime ProductionTime { get; set; }
        public int MinimalQuantity { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public ProductTypes Type { get; set; }
        public int Quantity { get; set; }

        public CosmeticProduct()
        {

        }
        public CosmeticProduct(CosmeticProduct cosmeticProduct)
        {
            DeliveryTime      = cosmeticProduct.DeliveryTime   ;
            ProductionTime    = cosmeticProduct.ProductionTime ;
            MinimalQuantity   = cosmeticProduct.MinimalQuantity;
            Name              = cosmeticProduct.Name           ;
            Price             = cosmeticProduct.Price          ;
            Type              = cosmeticProduct.Type           ;
            Quantity          = cosmeticProduct.Quantity       ;
        }
    }
}
