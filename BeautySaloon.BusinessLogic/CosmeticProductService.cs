using BeautySaloon.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeautySaloon.BusinessLogic
{
    public class CosmeticProductService : Interfaces.ICosmeticProductService
    {
        DataAccess.Interfaces.ICosmeticProductRepository repository { get; set; }
        Mappers.CosmeticProductMapper mapper { get; set; }

        public CosmeticProductService()
        {
            repository = new DataAccess.CosmeticProductRepository();
            mapper = new Mappers.CosmeticProductMapper();
        }

        public void Create(CosmeticProduct product)
        {
            repository.Add(mapper.ModelToEntity(product));
        }

        public void Delete(int id)
        {
            repository.Delete(id);
        }

        public CosmeticProduct GetById(int id)
        {
            return mapper.EntityToModel(repository.GetById(id));
        }
        
        public List<CosmeticProduct> GetByBankId(int id)
        {
            Interfaces.IBankService bankService = new BankService();

            return bankService.GetById(id).storage;
        }

        public List<CosmeticProduct> GetBySaloonId(int id)
        {
            Interfaces.ISaloonService saloonService = new SaloonService();

            return saloonService.GetById(id).storage;
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
    }
}
