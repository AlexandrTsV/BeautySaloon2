using System;
using System.Collections.Generic;
using System.Text;

namespace BeautySaloon.Mappers
{
    public class CosmeticProductMapper : Interfaces.IMapperToEntity<Entities.CosmeticProduct, Models.CosmeticProduct>, Interfaces.IMapperToModel<Entities.CosmeticProduct, Models.CosmeticProduct>
    {
        public CosmeticProductMapper()
        {
        }
        public Entities.CosmeticProduct ModelToEntity(Models.CosmeticProduct model)
        {
            return new Entities.CosmeticProduct()
            { 
                ID = model.id, 
                Name = model.Name, 
                Price = model.Price, 
                Quantity = model.Quantity, 
                ProductTypeID = (int)model.Type + 1,
                DeliveryTime = model.DeliveryTime, 
                ProductionTime = model.ProductionTime
            };
                
            
        }

        public Models.CosmeticProduct EntityToModel(Entities.CosmeticProduct entity)
        {
            Models.CosmeticProduct product = new Models.CosmeticProduct();
            
            if (entity.Type.StorageTime != null)
            {
                if (entity.Type.StorageTime >= TimeSpan.Parse("10:00:00"))
                {
                    product = new Models.CosmeticProductLongTerm();
                    ((Models.CosmeticProductLongTerm)product).StorageTime = (TimeSpan)entity.Type.StorageTime;
                }
                else
                {
                    product = new Models.CosmeticProductExpiration();
                    ((Models.CosmeticProductExpiration)product).StorageTime = (TimeSpan)entity.Type.StorageTime;
                }
            }
            
            product.id = entity.ID;
            product.Name = entity.Name;
            product.Price = entity.Price;
            product.Quantity = entity.Quantity;
            product.Type = (Models.ProductTypes)Enum.Parse(typeof(Models.ProductTypes), entity.Type.Name);
            product.DeliveryTime = entity.DeliveryTime;
            product.ProductionTime = (System.DateTime)entity.ProductionTime;
            product.id = entity.ID;
            product.MinimalQuantity = entity.Type.MinimalQuantity;
            return product;
        }
    }
}
