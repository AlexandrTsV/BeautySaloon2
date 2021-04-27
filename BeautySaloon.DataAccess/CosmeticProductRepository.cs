using BeautySaloon.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeautySaloon.DataAccess
{
    public class CosmeticProductRepository : Interfaces.IRepository<CosmeticProduct>, Interfaces.ICosmeticProductRepository
    {
        public BeautySaloonDbContext context { get; set; }
        public CosmeticProductRepository()
        {
            context = new BeautySaloonDbContext();
        }
        public void Add(CosmeticProduct entity)
        {
            context.CosmeticProducts.Add(entity);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            context.CosmeticProducts.Remove(context.CosmeticProducts.Find(id));

            foreach (var entry in context.SaloonProducts)
            {
                if (entry.productId == id)
                {
                    context.SaloonProducts.Remove(entry);
                }
            }
            foreach (var entry in context.BankProducts)
            {
                if (entry.productId == id)
                {
                    context.BankProducts.Remove(entry);
                }
            }

            context.SaveChanges();
        }

        public List<CosmeticProduct> GetAll()
        {
            List<CosmeticProduct> result = new List<CosmeticProduct>();
            foreach (var cosmeticProduct in context.CosmeticProducts)
            {
                result.Add(cosmeticProduct);
            }
            return result;
        }

        public CosmeticProduct GetById(int id)
        {
            return context.CosmeticProducts.Find(id);
        }

        public void Update(CosmeticProduct entity)
        {
            var tmp = context.CosmeticProducts.Find(entity.id);
            tmp.id = entity.id;
            tmp.name = entity.name;
            tmp.price = entity.price;
            // tmp.productionTime = entity.productionTime;
            tmp.quantity = entity.quantity;
            tmp.type = entity.type;

            context.SaveChanges();
        }
    }
}
