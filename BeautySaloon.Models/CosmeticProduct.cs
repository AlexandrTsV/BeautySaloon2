using System;
using System.Collections.Generic;
using System.Text;

namespace BeautySaloon.Models
{
    public enum ProductTypes
    {
        CosmeticProduct = 1,
        CosmeticProductExpiration,
        CosmeticProductLongTerm
    }

    public enum Services
    {
        Face = 1,
        Body,
        Hair,
        Lips
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
        public Services ServiceType { get; set; }
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
            ServiceType       = cosmeticProduct.ServiceType    ;
            Quantity          = cosmeticProduct.Quantity       ;
        }
    }
}
