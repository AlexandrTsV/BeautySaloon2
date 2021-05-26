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
        public void AddProduct(CosmeticProduct entity, Bank bank)
        {
            int status = 0;
            foreach (var product in GetProducts(bank))
            {
                if (product.Name == entity.Name)
                {
                    entity.ID = product.ID;
                    unitOfWork.CosmeticProducts.Update(entity);

                    status = 1;
                }
            }

            if (status == 0)
            {
                unitOfWork.CosmeticProducts.Add(entity);
                BankProduct bankProduct = new BankProduct() { CosmeticProductID = entity.ID, BankID = bank.ID, Quantity = 1000 };
                unitOfWork.db.BankProducts.Add(bankProduct);
            }

            unitOfWork.Save();
        }

        public List<CosmeticProduct> GetProducts(Bank bank)
        {
            List<CosmeticProduct> result = new List<CosmeticProduct>();

            List<int> toCompare = new List<int>();

            foreach (var entry in unitOfWork.db.BankProducts)
            {
                if (entry.BankID == bank.ID)
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
                foreach (var relation in unitOfWork.db.BankProducts)
                {
                    if (relation.CosmeticProduct.Name == product.CosmeticProduct.Name && relation.BankID == entity.ID)
                    {
                        relation.Quantity = product.Quantity;
                    }
                }
                unitOfWork.CosmeticProducts.Update(product.CosmeticProduct);
            }
            unitOfWork.Save();
        }
    }
}
