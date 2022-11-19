using System;
using System.Collections.Generic;
using System.Text;

namespace BeautySaloon.DataAccess.Interfaces
{
    public interface IBankRepository : IRepository<int, Entities.Bank>
    {
        // public bool Sell(Entities.CosmeticProduct entitiy, int id);
        public void AddProduct(Entities.CosmeticProduct entity, Entities.Bank bank);
        public List<Entities.CosmeticProduct> GetProducts(Entities.Bank bank);
    }
}
