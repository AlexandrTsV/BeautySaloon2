using System;
using System.Collections.Generic;
using System.Text;

namespace BeautySaloon.DataAccess.Interfaces
{
    public interface ISaloonRepository : IRepository<Entities.Saloon>
    {
        public void AddProduct(Entities.CosmeticProduct entity, int id);
        public List<Entities.CosmeticProduct> GetProducts(int id);
    }
}
