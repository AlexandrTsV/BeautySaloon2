using BeautySaloon.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BeautySaloon.BusinessLogic
{
    public class BankService : Interfaces.IBankService
    {
        DataAccess.Interfaces.IBankRepository repository { get; set; }
        Mappers.BankMapper mapper { get; set; }

        public BankService()
        {
            repository = new DataAccess.BankRepository();
            mapper = new Mappers.BankMapper();
        }

        public void AddProduct(CosmeticProduct product, int id)
        {
            Mappers.CosmeticProductMapper tmpMapper = new Mappers.CosmeticProductMapper();
            repository.AddProduct(tmpMapper.ModelToEntity(product), id);
        }

        public void Create(Bank bank)
        {
            repository.Add(mapper.ModelToEntity(bank));
        }

        public void Delete(int id)
        {
            repository.Delete(id);
        }

        public List<CosmeticProduct> ExecuteOrder(List<CosmeticProduct> products, int id)
        {
            List<CosmeticProduct> result = new List<CosmeticProduct>();
            Mappers.CosmeticProductMapper tmpMapper = new Mappers.CosmeticProductMapper();
            Interfaces.ICosmeticProductService cosmeticProductService = new CosmeticProductService();

            foreach (var product in products)
            {
                foreach (var inner in GetById(id).storage)
                {
                    if (product.name == inner.name)
                    {
                        if (product.quantity < inner.quantity)
                        {
                            inner.quantity -= product.quantity;
                            product.productionTime = inner.productionTime;
                            cosmeticProductService.Update(inner);
                            result.Add(product);
                        }
                    }
                }
            }
            return result;
        }

        public List<Bank> GetBanks()
        {
            List<Bank> banks = new List<Bank>();
            foreach (var bank in repository.GetAll())
            {
                banks.Add(mapper.EntityToModel(bank));
            }
            return banks;
        }

        public Bank GetById(int id)
        {
            return mapper.EntityToModel(repository.GetById(id));
        }

        public void Update(Bank bank)
        {
            repository.Update(mapper.ModelToEntity(bank));
        }
    }
}
