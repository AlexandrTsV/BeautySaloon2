using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace BeautySaloon.Mappers
{
    public class SaloonMapper : Interfaces.IMapperToEntity<Entities.Saloon, Models.Saloon>, Interfaces.IMapperToModel<Entities.Saloon, Models.Saloon>
    {
        public SaloonMapper()
        {
        }
        public Entities.Saloon ModelToEntity(Models.Saloon model)
        {
            Entities.Saloon saloon = new Entities.Saloon();
            saloon.Storage = new Collection<Entities.SaloonProduct>();
            saloon.ID = model.id;

            Interfaces.IMapperToEntity<Entities.CosmeticProduct, Models.CosmeticProduct> productMapper = new CosmeticProductMapper();

            foreach (var product in model.storage)
            {
                Entities.SaloonProduct tmp = new Entities.SaloonProduct { CosmeticProduct = productMapper.ModelToEntity(product), CosmeticProductID = productMapper.ModelToEntity(product).ID, Saloon = saloon, SaloonID = saloon.ID };
                saloon.Storage.Add(tmp);
            }

            return saloon;
        }

        public Models.Saloon EntityToModel(Entities.Saloon entity)
        {
            Models.Saloon saloon = new Models.Saloon();
            saloon.id = entity.ID;
            saloon.storage = new List<Models.CosmeticProduct>();

            Interfaces.IMapperToModel<Entities.CosmeticProduct, Models.CosmeticProduct> productMapper = new CosmeticProductMapper();

            foreach (var product in entity.Storage)
            {
                saloon.storage.Add(productMapper.EntityToModel(product.CosmeticProduct));
            }
            return saloon;
        }
    }
}
