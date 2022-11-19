using System;
using System.Collections.Generic;
using System.Text;

namespace BeautySaloon.DataAccess.Interfaces
{
    public interface ISaloonRepository : IRepository<int, Entities.Saloon>
    {
        public void AddProduct(Entities.CosmeticProduct entity, Entities.Saloon saloon);
        public List<Entities.CosmeticProduct> GetProducts(Entities.Saloon saloon);
    }
}
