using BeautySaloon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BeautySaloon.BusinessLogic
{
    public class CosmeticProductService : Interfaces.ICosmeticProductService
    {
        DataAccess.Interfaces.ICosmeticProductRepository repository { get; set; }
        Mappers.CosmeticProductMapper mapper { get; set; }

        public CosmeticProductService(DataAccess.Interfaces.ICosmeticProductRepository rep)
        {
            repository = rep;
            mapper = new Mappers.CosmeticProductMapper();
        }

        public void Create(CosmeticProduct product)
        {
            repository.Add(mapper.ModelToEntity(product));
        }

        public void Delete(CosmeticProduct product)
        {
            repository.Delete(mapper.ModelToEntity(product));
        }
        /* public List<CosmeticProduct> DeleteExpired(List<CosmeticProduct> products)
        {
            foreach (CosmeticProduct product in products)
            {
                if (typeof(IExpiration).IsAssignableFrom(product.GetType()))
                {
                    if (product.ProductionTime + ((IExpiration)product).StorageTime < DateTime.Now)
                    {
                        Delete(product);
                    }
                }
            }
            return products;
        } */

        public CosmeticProduct GetById(int id)
        {
            return mapper.EntityToModel(repository.GetById(id));
        }
        
        public List<CosmeticProduct> GetByBank(Bank bank)
        {
            return bank.storage;
        }

        public List<CosmeticProduct> GetBySaloon(Saloon saloon)
        {
            return saloon.storage;
        }

        public List<CosmeticProduct> GetCosmeticProducts()
        {
            List<CosmeticProduct> products = new List<CosmeticProduct>();
            foreach (var product in repository.GetAll())
            {
                products.Add(mapper.EntityToModel(product));
            }
            return products;
        }

        public void Update(CosmeticProduct product)
        {
            repository.Update(mapper.ModelToEntity(product));
        }
        public List<Models.Services> GetServices()
        {
            return Enum.GetValues(typeof(Models.Services)).Cast<Models.Services>().ToList();
        }
        public List<Models.ProductTypes> GetTypes()
        {
            return Enum.GetValues(typeof(Models.ProductTypes)).Cast<Models.ProductTypes>().ToList();
        }
    }
}
