using System;
using System.Collections.Generic;
using System.Text;

namespace BeautySaloon.Mappers
{
    public class SaloonMapper : Interfaces.IMapperToEntity<Entities.Saloon, Models.Saloon>, Interfaces.IMapperToModel<Entities.Saloon, Models.Saloon>
    {
        private List<Entities.CosmeticProduct> ToEntitiesList(List<Models.CosmeticProduct> products)
        {
            Interfaces.IMapperToEntity<Entities.CosmeticProduct, Models.CosmeticProduct> mapper = new CosmeticProductMapper();

            List<Entities.CosmeticProduct> result = new List<Entities.CosmeticProduct>();
            foreach (Models.CosmeticProduct product in products)
            {
                result.Add(mapper.ModelToEntity(product));
            }
            return result;
        }

        private List<Models.CosmeticProduct> ToModelsList(List<Entities.CosmeticProduct> products)
        {
            Interfaces.IMapperToModel<Entities.CosmeticProduct, Models.CosmeticProduct> mapper = new CosmeticProductMapper();

            List<Models.CosmeticProduct> result = new List<Models.CosmeticProduct>();
            foreach (Entities.CosmeticProduct product in products)
            {
                result.Add(mapper.EntityToModel(product));
            }
            return result;
        }
        public Entities.Saloon ModelToEntity(Models.Saloon model)
        {
            Entities.Saloon saloon = new Entities.Saloon();
            saloon.id = model.id;
            return saloon;
        }

        public Models.Saloon EntityToModel(Entities.Saloon entity)
        {
            Models.Saloon saloon = new Models.Saloon();
            saloon.id = entity.id;
            saloon.storage = new List<Models.CosmeticProduct>();

            Interfaces.IMapperToModel<Entities.CosmeticProduct, Models.CosmeticProduct> productMapper = new CosmeticProductMapper();
            DataAccess.Interfaces.ISaloonRepository repository = new DataAccess.SaloonRepository();

            foreach (var product in repository.GetProducts(saloon.id))
            {
                saloon.storage.Add(productMapper.EntityToModel(product));
            }
            return saloon;
        }
    }
}
