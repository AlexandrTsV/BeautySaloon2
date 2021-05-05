using System;
using System.Collections.Generic;

namespace BeautySaloon.Commands
{
    public class Commands
    {

        private Mappers.BankMapper bankMapper = new Mappers.BankMapper();
        private Mappers.CosmeticProductMapper cosmeticProductMapper = new Mappers.CosmeticProductMapper();
        private Mappers.SaloonMapper saloonMapper = new Mappers.SaloonMapper();


        private DataAccess.BankRepository bankRepository = new DataAccess.BankRepository();
        private DataAccess.CosmeticProductRepository cosmeticProductRepository = new DataAccess.CosmeticProductRepository();
        private DataAccess.SaloonRepository saloonRepository = new DataAccess.SaloonRepository();

        // private BusinessLogic.Interfaces.IBankService bankService;
        // private BusinessLogic.Interfaces.ICosmeticProductService cosmeticProductService;
        // private BusinessLogic.Interfaces.ISaloonService saloonService;

        private int saloonId = 1;
        private int bankId = 1;

        public List<Models.CosmeticProduct> GetAllProducts()
        {
            List<Models.CosmeticProduct> result = new List<Models.CosmeticProduct>();
            foreach (var product in saloonMapper.EntityToModel(saloonRepository.GetById(saloonId)).storage)
            {
                result.Add(product);
            }
            return result;
        }

        public void OrderProduct(Models.CosmeticProduct cosmeticProduct, int quantity)
        {
            foreach (var product in saloonMapper.EntityToModel(saloonRepository.GetById(saloonId)).storage)
            {
                if (cosmeticProduct.name == product.name)
                {
                    var tmpProduct = product.Construct();
                    tmpProduct.quantity = quantity;

                    foreach (var inner in bankMapper.EntityToModel(bankRepository.GetById(bankId)).storage)
                    {
                        if (tmpProduct.name == inner.name)
                        {
                            if (tmpProduct.quantity < inner.quantity)
                            {
                                inner.quantity -= quantity;
                                tmpProduct.productionTime = inner.productionTime;
                                cosmeticProductRepository.Update(cosmeticProductMapper.ModelToEntity(inner));

                                saloonRepository.AddProduct(cosmeticProductMapper.ModelToEntity(tmpProduct), saloonId);
                            }
                        }
                    }

                }
            }
        }

        public void OrderNeeded()
        {
            foreach (var product in saloonMapper.EntityToModel(saloonRepository.GetById(saloonId)).storage)
            {
                if (product.IsNeeded() > 0)
                {
                    var tmpProduct = product.Construct();
                    tmpProduct.quantity = product.IsNeeded();
                    if (typeof(Models.IExpiration).IsAssignableFrom(product.GetType()))
                    {
                        if (((Models.IExpiration)product).IsExpired())
                        {
                            cosmeticProductRepository.Delete(product.id);
                        }
                    }

                    foreach (var inner in bankMapper.EntityToModel(bankRepository.GetById(bankId)).storage)
                    {
                        if (tmpProduct.name == inner.name)
                        {
                            if (tmpProduct.quantity < inner.quantity)
                            {
                                inner.quantity -= tmpProduct.quantity;
                                tmpProduct.productionTime = inner.productionTime;
                                cosmeticProductRepository.Update(cosmeticProductMapper.ModelToEntity(inner));

                                saloonRepository.AddProduct(cosmeticProductMapper.ModelToEntity(tmpProduct), saloonId);
                            }
                        }
                    }

                }
            }
        }

        public List<Models.CosmeticProduct> GetBankProducts()
        {
            List<Models.CosmeticProduct> result = new List<Models.CosmeticProduct>();
            foreach (var product in bankMapper.EntityToModel(bankRepository.GetById(bankId)).storage)
            {
                result.Add(product);
            }
            return result;
        }
        public List<Models.CosmeticProduct> GetNeededProducts()
        {
            List<Models.CosmeticProduct> result = new List<Models.CosmeticProduct>();
            foreach (var product in saloonMapper.EntityToModel(saloonRepository.GetById(saloonId)).storage)
            {
                if (product.IsNeeded() > 0) result.Add(product);
            }
            return result;
        }

        
        public Commands()
        {
            // bankService = new BusinessLogic.BankService();
            // cosmeticProductService = new BusinessLogic.CosmeticProductService();
            // saloonService = new BusinessLogic.SaloonService();
        }
    }
}
