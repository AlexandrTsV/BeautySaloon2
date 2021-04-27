using System;
using System.Collections.Generic;
using System.Text;

namespace BeautySaloon.DataAccess.Interfaces
{
    public interface IBankRepository : IRepository<Entities.Bank>
    {
        // public bool Sell(Entities.CosmeticProduct entitiy, int id);
        public void AddProduct(Entities.CosmeticProduct entity, int id);
        public List<Entities.CosmeticProduct> GetProducts(int id);
    }
}
