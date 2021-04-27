using BeautySaloon.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeautySaloon.DataAccess
{
    public class BankRepository : Interfaces.IRepository<Bank>, Interfaces.IBankRepository
    {
        public BeautySaloonDbContext context { get; set; }
        
        public BankRepository()
        {
            context = new BeautySaloonDbContext();
        }
        public void AddProduct(CosmeticProduct entity, int id)
        {
            throw new NotImplementedException();
        }

        public List<CosmeticProduct> GetProducts(int id)
        {
            List<CosmeticProduct> result = new List<CosmeticProduct>();

            List<int> toCompare = new List<int>();

            foreach (var entry in context.BankProducts)
            {
                if (entry.bankId == id)
                {
                    toCompare.Add(entry.productId);
                }
            }

            foreach (var product in context.CosmeticProducts)
            {
                if (toCompare.Contains(product.id))
                {
                    result.Add(product);
                }
            }

            return result;
        }

        /* public bool Sell(CosmeticProduct entity, int id)
        {
            Interfaces.ICosmeticProductRepository repository = new CosmeticProductRepository();


        } */

        public void Add(Bank entity)
        {
            context.Banks.Add(entity);
        }

        public void Delete(int id)
        {
            context.Banks.Remove(context.Banks.Find(id));
        }

        public List<Bank> GetAll()
        {
            List<Bank> result = new List<Bank>();
            foreach (var bank in context.Banks)
            {
                result.Add(bank);
            }
            return result;
        }

        public Bank GetById(int id)
        {
            return context.Banks.Find(id);
        }

        public void Update(Entities.Bank entity)
        {
            context.Banks.Find(entity.id).id = entity.id;
        }
    }
}
