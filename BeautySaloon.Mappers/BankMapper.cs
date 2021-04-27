using System;
using System.Collections.Generic;

namespace BeautySaloon.Mappers
{
    public class BankMapper : Interfaces.IMapperToEntity<Entities.Bank, Models.Bank>, Interfaces.IMapperToModel<Entities.Bank, Models.Bank>
    {
        private List<Entities.CosmeticProduct> ToEntitiesList(List<Models.CosmeticProduct> products) {
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
        public Entities.Bank ModelToEntity(Models.Bank model)
        {
            Entities.Bank bank = new Entities.Bank();
            bank.id = model.id;
            return bank;
        }

        public Models.Bank EntityToModel(Entities.Bank entity)
        {
            Models.Bank bank = new Models.Bank();
            bank.id = entity.id;
            bank.storage = new List<Models.CosmeticProduct>();

            Interfaces.IMapperToModel<Entities.CosmeticProduct, Models.CosmeticProduct> productMapper = new CosmeticProductMapper();
            DataAccess.Interfaces.IBankRepository repository = new DataAccess.BankRepository();

            foreach (var product in repository.GetProducts(bank.id))
            {
                bank.storage.Add(productMapper.EntityToModel(product));
            }
            return bank;
        }
    }
}
