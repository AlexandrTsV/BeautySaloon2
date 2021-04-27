using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BeautySaloon.BusinessLogic.Interfaces
{
    public interface ISaloonService
    {
        public void Create(Models.Saloon saloon);
        public void Update(Models.Saloon saloon);
        public void Delete(int id);
        public Models.Saloon GetById(int id);
        // public List<Models.Saloon> GetSaloons();
        public List<Models.CosmeticProduct> FormOrder(int id);
        public List<Models.CosmeticProduct> GetAllNeededProducts(int id);
        public void AddProduct(Models.CosmeticProduct product, int id);
    }
}
