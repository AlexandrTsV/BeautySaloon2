using BeautySaloon.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeautySaloon.DataAccess
{
    public class SaloonRepository : Interfaces.IRepository<Saloon>, Interfaces.ISaloonRepository
    {
        public BeautySaloonDbContext context { get; set; }
        public SaloonRepository()
        {
            context = new BeautySaloonDbContext();
        }
        public void AddProduct(CosmeticProduct entity, int id)
        {
            Interfaces.ICosmeticProductRepository cosmeticProductRepository = new CosmeticProductRepository();

            int status = 0;
            foreach (var product in cosmeticProductRepository.GetAll())
            {
                if (product.id == entity.id)
                {
                    entity.quantity += product.quantity;
                    cosmeticProductRepository.Update(entity);

                    status = 1;
                }
            }

            if (status == 0)
            {
                cosmeticProductRepository.Add(entity);
                SaloonProduct saloonProduct = new SaloonProduct() { productId = entity.id, saloonId = id };
                context.SaloonProducts.Add(saloonProduct);
            }

            context.SaveChanges();
        }

        public List<CosmeticProduct> GetProducts(int id)
        {
            List<CosmeticProduct> result = new List<CosmeticProduct>();

            List<int> toCompare = new List<int>();

            foreach (var entry in context.SaloonProducts)
            {
                if (entry.saloonId == id)
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
        public void Add(Saloon entity)
        {
            context.Saloons.Add(entity);
        }

        public void Delete(int id)
        {
            context.Saloons.Remove(context.Saloons.Find(id));
        }

        public List<Saloon> GetAll()
        {
            List<Saloon> result = new List<Saloon>();
            foreach (var saloon in context.Saloons)
            {
                result.Add(saloon);
            }
            return result;
        }

        public Saloon GetById(int id)
        {
            return context.Saloons.Find(id);
        }

        public void Update(Saloon entity)
        {
            context.Saloons.Find(entity.id).id = entity.id;
        }
    }
}
