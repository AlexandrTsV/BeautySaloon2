using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BeautySaloon.BusinessLogic.Interfaces
{
    public interface IBankService
    {
        public void Create(Models.Bank bank);
        public void Update(Models.Bank bank);
        public void Delete(int id);
        public Models.Bank GetById(int id);
        public List<Models.CosmeticProduct> ExecuteOrder(List<Models.CosmeticProduct> products, int id);
        public void AddProduct(Models.CosmeticProduct product, int id);
    }
}
