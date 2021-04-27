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
        public void Delete(int id);
        public List<Models.CosmeticProduct> GetByBankId(int id);
        public List<Models.CosmeticProduct> GetBySaloonId(int id);
        public List<Models.CosmeticProduct> GetCosmeticProducts();
        public Models.CosmeticProduct GetById(int id);
    }
}
