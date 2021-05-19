using BeautySaloon.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeautySaloon.BusinessLogic
{
    public class SaloonService : Interfaces.ISaloonService
    {
        DataAccess.Interfaces.ISaloonRepository repository { get; set; }
        Mappers.SaloonMapper mapper { get; set; }

        public SaloonService(DataAccess.Interfaces.ISaloonRepository rep)
        {
            repository = rep;
            mapper = new Mappers.SaloonMapper();
        }
        public void AddProduct(CosmeticProduct product, Saloon saloon)
        {
            Mappers.CosmeticProductMapper tmpMapper = new Mappers.CosmeticProductMapper();
            repository.AddProduct(tmpMapper.ModelToEntity(product), mapper.ModelToEntity(saloon));
        }
        public void Create(Saloon saloon)
        {
            repository.Add(mapper.ModelToEntity(saloon));
        }

        public void Delete(Saloon saloon)
        {
            repository.Delete(mapper.ModelToEntity(saloon));
        }

        public List<Saloon> GetSaloons()
        {
            List<Saloon> saloons = new List<Saloon>();
            foreach (var saloon in repository.GetAll())
            {
                saloons.Add(mapper.EntityToModel(saloon));
            }
            return saloons;
        }

        public Saloon GetById(int id)
        {
            return mapper.EntityToModel(repository.GetById(id));
        }

        public void Update(Saloon saloon)
        {
            repository.Update(mapper.ModelToEntity(saloon));
        }


        public List<CosmeticProduct> GetAllNeededProducts(Saloon saloon)
        {

            List<CosmeticProduct> products = new List<CosmeticProduct>();
            foreach (var product in saloon.storage)
            {
                if (product.Quantity < product.MinimalQuantity)
                {
                    products.Add(product);
                }
                else if (typeof(IExpiration).IsAssignableFrom(product.GetType()))
                {
                    if (product.ProductionTime + ((IExpiration)product).StorageTime < DateTime.Now)
                    {
                        products.Add(product);
                    }
                }
            }
            return products;
        }

        public List<CosmeticProduct> FormOrder(Saloon saloon)
        {
            List<CosmeticProduct> products = new List<CosmeticProduct>();
            foreach (var product in saloon.storage)
            {
                if (product.Quantity < product.MinimalQuantity)
                {
                    var tmpProduct = new CosmeticProduct(product);
                    tmpProduct.Quantity = product.MinimalQuantity - product.Quantity;
                    products.Add(tmpProduct);
                }
                else if (typeof(IExpiration).IsAssignableFrom(product.GetType()))
                {
                    if (product.ProductionTime + ((IExpiration)product).StorageTime < DateTime.Now)
                    {
                        var tmpProduct = new CosmeticProduct(product);
                        tmpProduct.Quantity = product.MinimalQuantity;
                        product.Quantity = 0;
                        repository.Update(mapper.ModelToEntity(saloon));
                        products.Add(tmpProduct);
                    }
                }
            }
            return products;
        }
    }
}
