using BeautySaloon.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeautySaloon.BusinessLogic
{
    /*
    public class SaloonService : Interfaces.ISaloonService
    {
        DataAccess.Interfaces.ISaloonRepository repository { get; set; }
        Mappers.SaloonMapper mapper { get; set; }

        public SaloonService()
        {
            repository = new DataAccess.SaloonRepository();
            mapper = new Mappers.SaloonMapper();
        }
        public void AddProduct(CosmeticProduct product, int id)
        {
            Mappers.CosmeticProductMapper tmpMapper = new Mappers.CosmeticProductMapper();
            repository.AddProduct(tmpMapper.ModelToEntity(product), id);
        }
        public void Create(Saloon saloon)
        {
            repository.Add(mapper.ModelToEntity(saloon));
        }

        public void Delete(int id)
        {
            repository.Delete(id);
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


        public List<CosmeticProduct> GetAllNeededProducts(int id)
        {

            List<CosmeticProduct> products = new List<CosmeticProduct>();
            foreach (var product in GetById(id).storage)
            {
                if (product.IsNeeded() > 0)
                {
                    products.Add(product);
                }
            }
            return products;
        }

        public List<CosmeticProduct> FormOrder(int id)
        {

            List<CosmeticProduct> products = new List<CosmeticProduct>();
            foreach (var product in GetById(id).storage)
            {
                if (product.IsNeeded() > 0)
                {
                    var tmpProduct = product.Construct();
                    tmpProduct.quantity = product.IsNeeded();
                    if (typeof(IExpiration).IsAssignableFrom(product.GetType()))
                    {
                        if (((IExpiration)product).IsExpired())
                        {
                            (new CosmeticProductService()).Delete(product.id);
                        }
                    }
                    products.Add(tmpProduct);
                }
            }
            return products;
        }
    } */
}
