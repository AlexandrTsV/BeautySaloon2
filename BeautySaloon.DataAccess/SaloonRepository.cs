using BeautySaloon.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeautySaloon.DataAccess
{
    public class SaloonRepository : Interfaces.ISaloonRepository
    {
        public UnitOfWork unitOfWork { get; set; }
        public SaloonRepository(UnitOfWork uow)
        {
            unitOfWork = uow;
        }
        public void AddProduct(CosmeticProduct entity, Entities.Saloon saloon)
        {
            int status = 0;
            foreach (var product in GetProducts(saloon))
            {
                if (product.Name == entity.Name)
                {
                    foreach (var relation in unitOfWork.db.SaloonProducts)
                    {
                        if (relation.CosmeticProduct.Name == product.Name && relation.SaloonID == entity.ID)
                        {
                            // TODO
                            //relation.Quantity = product.Quantity;
                        }
                    }
                    entity.ID = product.ID;
                    unitOfWork.CosmeticProducts.Update(entity);

                    status = 1;
                }
            }

            if (status == 0)
            {
                unitOfWork.CosmeticProducts.Add(entity);
                SaloonProduct saloonProduct = new SaloonProduct() { CosmeticProductID = entity.ID, SaloonID = saloon.ID };
                unitOfWork.db.SaloonProducts.Add(saloonProduct);
            }

            unitOfWork.Save();
        }

        public List<CosmeticProduct> GetProducts(Saloon saloon)
        {
            List<CosmeticProduct> result = new List<CosmeticProduct>();

            foreach (var entry in saloon.Storage)
            {
                result.Add(entry.CosmeticProduct);
            }

            return result;
        }
        public void Add(Saloon entity)
        {
            unitOfWork.db.Saloons.Add(entity);
        }

        public void Delete(Saloon entity)
        {
            unitOfWork.db.Saloons.Remove(unitOfWork.db.Saloons.Find(entity.ID));
        }

        public List<Saloon> GetAll()
        {
            List<Saloon> result = new List<Saloon>();
            foreach (var saloon in unitOfWork.db.Saloons)
            {
                result.Add(saloon);
            }
            return result;
        }

        public Saloon GetById(int id)
        {
            return unitOfWork.db.Saloons.Find(id);
        }

        public void Update(Saloon entity)
        {
            unitOfWork.db.Saloons.Find(entity.ID).ID = entity.ID;

            foreach (var product in entity.Storage)
            {
                int status = 0;
                foreach (var relation in unitOfWork.db.SaloonProducts)
                {
                    if (relation.CosmeticProduct.Name == product.CosmeticProduct.Name && relation.SaloonID == entity.ID)
                    {
                        relation.Quantity = product.Quantity;
                        status = 1;
                    }
                }
                if (status == 0)
                {
                    unitOfWork.db.SaloonProducts.Add(new Entities.SaloonProduct { 
                        CosmeticProductID = product.CosmeticProductID,
                        SaloonID = product.SaloonID,
                        Quantity = product.Quantity
                    });
                    unitOfWork.Save();
                }
                else
                {
                    unitOfWork.CosmeticProducts.Update(product.CosmeticProduct);
                }
            }
        }
    }
}
