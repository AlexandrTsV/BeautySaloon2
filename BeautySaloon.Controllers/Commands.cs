using System;
using System.Collections.Generic;

namespace BeautySaloon.Commands
{
    public class Commands
    {

        private Mappers.BankMapper bankMapper;
        private Mappers.CosmeticProductMapper cosmeticProductMapper;
        private Mappers.SaloonMapper saloonMapper;

        private BusinessLogic.Interfaces.IBankService bankService;
        private BusinessLogic.Interfaces.ICosmeticProductService cosmeticProductService;
        private BusinessLogic.Interfaces.ISaloonService saloonService;

        private DataAccess.UnitOfWork unitOfWork = new DataAccess.UnitOfWork();

        // private BusinessLogic.Interfaces.IBankService bankService;
        // private BusinessLogic.Interfaces.ICosmeticProductService cosmeticProductService;
        // private BusinessLogic.Interfaces.ISaloonService saloonService;

        private int saloonId = 1;
        private int bankId = 1;
        public Commands()
        {
            unitOfWork.db = new DataAccess.BeautySaloonDbContext();
            unitOfWork.CosmeticProducts = new DataAccess.CosmeticProductRepository(unitOfWork);
            unitOfWork.Banks = new DataAccess.BankRepository(unitOfWork);
            unitOfWork.Saloons = new DataAccess.SaloonRepository(unitOfWork);

            bankMapper = new Mappers.BankMapper();
            cosmeticProductMapper = new Mappers.CosmeticProductMapper();
            saloonMapper = new Mappers.SaloonMapper();

            bankService = new BusinessLogic.BankService(unitOfWork.Banks);
            cosmeticProductService = new BusinessLogic.CosmeticProductService(unitOfWork.CosmeticProducts);
            saloonService = new BusinessLogic.SaloonService(unitOfWork.Saloons);
        }

        public List<Models.CosmeticProduct> GetAllProducts()
        {
            return cosmeticProductService.GetBySaloon(saloonService.GetById(saloonId));
            //List<Models.CosmeticProduct> result = new List<Models.CosmeticProduct>();
            //foreach (var product in saloonMapper.EntityToModel(unitOfWork.Saloons.GetById(saloonId)).storage)
            //{
            //    result.Add(product);
            //}
            //return result;
        }

        public void OrderProduct(Models.CosmeticProduct cosmeticProduct, int quantity)
        {
            saloonService.AddProduct(bankService.Sell(cosmeticProduct, quantity, bankService.GetById(bankId)), saloonService.GetById(saloonId));
        }

        public void OrderNeeded()
        {
            foreach (var product in bankService.ExecuteOrder(saloonService.FormOrder(saloonService.GetById(saloonId)), bankService.GetById(bankId)))
            {
                saloonService.AddProduct(product, saloonService.GetById(saloonId));
            }
        }

        public List<Models.CosmeticProduct> GetBankProducts()
        {
            return cosmeticProductService.GetByBank(bankService.GetById(bankId));
        }
        public List<Models.CosmeticProduct> GetNeededProducts()
        {
            return saloonService.GetAllNeededProducts(saloonService.GetById(saloonId));
        }
    }
}
