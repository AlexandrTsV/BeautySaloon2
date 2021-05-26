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

        public BankService(DataAccess.Interfaces.IBankRepository rep)
        {
            repository = rep;
            mapper = new Mappers.BankMapper();
        }

        public void AddProduct(CosmeticProduct product, Bank bank)
        {
            Mappers.CosmeticProductMapper tmpMapper = new Mappers.CosmeticProductMapper();
            repository.AddProduct(tmpMapper.ModelToEntity(product), mapper.ModelToEntity(bank));
        }

        public void Create(Bank bank)
        {
            repository.Add(mapper.ModelToEntity(bank));
        }

        public void Delete(Bank bank)
        {
            repository.Delete(mapper.ModelToEntity(bank));
        }

        public List<CosmeticProduct> ExecuteOrder(List<CosmeticProduct> products, Bank bank)
        {
            List<CosmeticProduct> result = new List<CosmeticProduct>();

            foreach (var product in products)
            {
                foreach (var inner in bank.storage)
                {
                    if (product.Name == inner.Name)
                    {
                        if (product.Quantity < inner.Quantity)
                        {
                            inner.Quantity -= product.Quantity;
                            product.ProductionTime = inner.ProductionTime;
                            repository.Update(mapper.ModelToEntity(bank));
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

        public CosmeticProduct Sell(CosmeticProduct cosmeticProduct, int quantity, Bank bank)
        {
            foreach (var product in bank.storage)
            {
                if (cosmeticProduct.Name == product.Name)
                {
                    if (quantity < product.Quantity)
                    {
                        cosmeticProduct.Quantity = quantity;
                        product.Quantity -= quantity;
                        cosmeticProduct.ProductionTime = product.ProductionTime;
                        repository.Update(mapper.ModelToEntity(bank));
                        return cosmeticProduct;
                    }
                }
            }
            return null;
        }
    } 
}
