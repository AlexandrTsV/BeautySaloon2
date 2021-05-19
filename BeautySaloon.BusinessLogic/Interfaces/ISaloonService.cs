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
        public void Delete(Models.Saloon saloon);
        public Models.Saloon GetById(int id);
        public List<Models.CosmeticProduct> FormOrder(Models.Saloon saloon);
        public List<Models.CosmeticProduct> GetAllNeededProducts(Models.Saloon saloon);
        public void AddProduct(Models.CosmeticProduct product, Models.Saloon saloon);
    }
}
