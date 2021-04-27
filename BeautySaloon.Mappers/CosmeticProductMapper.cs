using System;
using System.Collections.Generic;
using System.Text;

namespace BeautySaloon.Mappers
{
    public class CosmeticProductMapper : Interfaces.IMapperToEntity<Entities.CosmeticProduct, Models.CosmeticProduct>, Interfaces.IMapperToModel<Entities.CosmeticProduct, Models.CosmeticProduct>
    {
        public Entities.CosmeticProduct ModelToEntity(Models.CosmeticProduct model)
        {
            return new Entities.CosmeticProduct()
            { 
                id = model.id, 
                name = model.name, 
                price = model.price, 
                quantity = model.quantity, 
                type = model.type, 
                deliveryTime = model.deliveryTime, 
                // productionTime = model.productionTime 
            };
                
            
        }

        public Models.CosmeticProduct EntityToModel(Entities.CosmeticProduct entity)
        {
            Models.CosmeticProduct product = new Models.CosmeticProduct();

            foreach (var asm in AppDomain.CurrentDomain.GetAssemblies())
            {
                Type type = asm.GetType("BeautySaloon.Models." + entity.type);
                if (type != null) {
                    product = (BeautySaloon.Models.CosmeticProduct)Activator.CreateInstance(type);
                }
            }
            product.id = entity.id;
            product.name = entity.name;
            product.price = entity.price;
            product.quantity = entity.quantity;
            product.type = entity.type;
            product.deliveryTime = entity.deliveryTime;
            product.productionTime = (System.DateTime)entity.productionTime;
            product.id = entity.id;
            return product;
        }
    }
}
