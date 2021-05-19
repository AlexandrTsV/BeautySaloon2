using BeautySaloon.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeautySaloon.DataAccess
{
    public class BankRepository : Interfaces.IBankRepository
    {
        public UnitOfWork unitOfWork { get; set; }

        public BankRepository(UnitOfWork uow)
        {
            unitOfWork = uow;
        }
        public void AddProduct(CosmeticProduct entity, int id)
        {
            throw new NotImplementedException();
        }

        public List<CosmeticProduct> GetProducts(int id)
        {
            List<CosmeticProduct> result = new List<CosmeticProduct>();

            List<int> toCompare = new List<int>();

            foreach (var entry in unitOfWork.db.BankProducts)
            {
                if (entry.BankID == id)
                {
                    toCompare.Add(entry.CosmeticProductID);
                }
            }

            foreach (var product in unitOfWork.db.CosmeticProducts)
            {
                if (toCompare.Contains(product.ID))
                {
                    result.Add(product);
                }
            }

            return result;
        }

        public void Add(Bank entity)
        {
            unitOfWork.db.Banks.Add(entity);
        }

        public void Delete(Bank entity)
        {
            unitOfWork.db.Banks.Remove(unitOfWork.db.Banks.Find(entity.ID));
        }

        public List<Bank> GetAll()
        {
            List<Bank> result = new List<Bank>();
            foreach (var bank in unitOfWork.db.Banks)
            {
                result.Add(bank);
            }
            return result;
        }

        public Bank GetById(int id)
        {
            return unitOfWork.db.Banks.Find(id);
        }

        public void Update(Entities.Bank entity)
        {
            unitOfWork.db.Banks.Find(entity.ID).ID = entity.ID;

            foreach (var product in entity.Storage)
            {
                unitOfWork.CosmeticProducts.Update(product.CosmeticProduct);
            }
            unitOfWork.Save();
        }
    }
}
