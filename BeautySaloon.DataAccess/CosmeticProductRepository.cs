using BeautySaloon.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BeautySaloon.DataAccess
{
    public class CosmeticProductRepository : Interfaces.ICosmeticProductRepository
    {
        public UnitOfWork unitOfWork { get; set; }
        public CosmeticProductRepository(UnitOfWork uow)
        {
            unitOfWork = uow;
        }
        public void Add(CosmeticProduct entity)
        {
            unitOfWork.db.CosmeticProducts.Add(entity);
            unitOfWork.Save();
        }

        public void Delete(CosmeticProduct entity)
        {
            unitOfWork.db.CosmeticProducts.Remove(unitOfWork.db.CosmeticProducts.Find(entity.ID));

            foreach (var entry in unitOfWork.db.SaloonProducts)
            {
                if (entry.CosmeticProductID == entity.ID)
                {
                    unitOfWork.db.SaloonProducts.Remove(entry);
                }
            }
            foreach (var entry in unitOfWork.db.BankProducts)
            {
                if (entry.CosmeticProductID == entity.ID)
                {
                    unitOfWork.db.BankProducts.Remove(entry);
                }
            }

            unitOfWork.Save();
        }

        public List<CosmeticProduct> GetAll()
        {
            List<CosmeticProduct> result = new List<CosmeticProduct>();
            var query = from c in unitOfWork.db.CosmeticProducts select c;

            foreach(var product in query)
            {
                result.Add(product);
            }

            return result;
        }

        public CosmeticProduct GetById(int id)
        {
            return unitOfWork.db.CosmeticProducts.Find(id);
        }

        public void Update(CosmeticProduct entity)
        {
            foreach (var tmp in unitOfWork.db.CosmeticProducts) {
                if (tmp.ID == entity.ID)
                {
                    tmp.Name = entity.Name;
                    tmp.Price = entity.Price;
                    tmp.ProductionTime = entity.ProductionTime;
                    tmp.MinimalQuantity = entity.MinimalQuantity;
                    tmp.ProductTypeID = entity.ProductTypeID;
                    tmp.StorageTime = entity.StorageTime;
                }
            }

            unitOfWork.Save();
        }
    }
}
