using BeautySaloon.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BeautySaloon.Mappers
{
    public class BankMapper : Interfaces.IMapperToEntity<Entities.Bank, Models.Bank>, Interfaces.IMapperToModel<Entities.Bank, Models.Bank>
    {
        public BankMapper()
        {
        }
        public Entities.Bank ModelToEntity(Models.Bank model)
        {
            Entities.Bank bank = new Entities.Bank();
            bank.Storage = new Collection<BankProduct>();
            bank.ID = model.id;

            Interfaces.IMapperToEntity<Entities.CosmeticProduct, Models.CosmeticProduct> productMapper = new CosmeticProductMapper();

            foreach (var product in model.storage)
            {
                Entities.BankProduct tmp = new Entities.BankProduct { CosmeticProduct = productMapper.ModelToEntity(product), CosmeticProductID = productMapper.ModelToEntity(product).ID, Bank = bank, BankID = bank.ID };
                bank.Storage.Add(tmp);
            }

            return bank;
        }

        public Models.Bank EntityToModel(Entities.Bank entity)
        {
            Models.Bank bank = new Models.Bank();
            bank.id = entity.ID;
            bank.storage = new List<Models.CosmeticProduct>();

            Interfaces.IMapperToModel<Entities.CosmeticProduct, Models.CosmeticProduct> productMapper = new CosmeticProductMapper();

            foreach (var product in entity.Storage)
            {
                bank.storage.Add(productMapper.EntityToModel(product.CosmeticProduct));
            }
            return bank;
        }
    }
}
