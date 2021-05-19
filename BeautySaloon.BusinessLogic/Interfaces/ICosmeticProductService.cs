using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BeautySaloon.BusinessLogic.Interfaces
{
    public interface ICosmeticProductService
    {
        public void Create(Models.CosmeticProduct product);
        public void Update(Models.CosmeticProduct product);
        public void Delete(Models.CosmeticProduct product);
        public List<Models.CosmeticProduct> GetByBank(Models.Bank bank);
        public List<Models.CosmeticProduct> GetBySaloon(Models.Saloon saloon);
        public List<Models.CosmeticProduct> GetCosmeticProducts();
        public Models.CosmeticProduct GetById(int id);
    }
}
