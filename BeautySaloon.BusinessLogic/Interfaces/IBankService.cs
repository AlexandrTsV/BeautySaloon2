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
        public void Delete(Models.Bank bank);
        public Models.CosmeticProduct Sell(Models.CosmeticProduct cosmeticProduct, int quantity, Models.Bank bank);
        public Models.Bank GetById(int id);
        public List<Models.CosmeticProduct> ExecuteOrder(List<Models.CosmeticProduct> products, Models.Bank bank);
        public void AddProduct(Models.CosmeticProduct product, Models.Bank bank);
    }
}
