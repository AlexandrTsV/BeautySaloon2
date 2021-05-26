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
            Entities.CosmeticProduct entity = new Entities.CosmeticProduct()
            {
                ID = model.id,
                Name = model.Name,
                Price = model.Price,
                ProductTypeID = (int)model.Type,
                ServiceID = (int)model.ServiceType,
                DeliveryTime = model.DeliveryTime,
                ProductionTime = model.ProductionTime,
                StorageTime = null,
                MinimalQuantity = model.MinimalQuantity,
                // Service = new Entities.Service { ID = (int)model.ServiceType, Name = model.ServiceType.ToString() }
            };

            if (model is Models.IExpiration) {
                entity.StorageTime = ((Models.IExpiration)model).StorageTime;
            }

            return entity;
        }

        public Models.CosmeticProduct EntityToModel(Entities.CosmeticProduct entity)
        {
            Models.CosmeticProduct product = new Models.CosmeticProduct();
                
            foreach (var asm in AppDomain.CurrentDomain.GetAssemblies())
            {
                Type type = asm.GetType("BeautySaloon.Models." + entity.Type.Name);
                if (type != null)
                    product = (Models.CosmeticProduct)Activator.CreateInstance(type);
            }

            if (product is Models.IExpiration)
            {
                ((Models.IExpiration)product).StorageTime = (TimeSpan)entity.StorageTime;
            }
            
            product.id = entity.ID;
            product.Name = entity.Name;
            product.Price = entity.Price;
            product.Type = (Models.ProductTypes)Enum.Parse(typeof(Models.ProductTypes), entity.Type.Name);
            product.ServiceType = (Models.Services)Enum.ToObject(typeof(Models.Services), entity.ServiceID);
            product.DeliveryTime = entity.DeliveryTime;
            product.ProductionTime = (System.DateTime)entity.ProductionTime;
            product.id = entity.ID;
            product.MinimalQuantity = entity.MinimalQuantity;
            return product;
        }
    }
}
