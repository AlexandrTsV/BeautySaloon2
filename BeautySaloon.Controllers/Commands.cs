using System;
using System.Collections.Generic;

namespace BeautySaloon.Commands
{
    public class Queue
    {
        public Models.CosmeticProduct product;
        public DateTime created;
    }
    public class Commands
    {
        private BusinessLogic.Interfaces.IBankService bankService;
        private BusinessLogic.Interfaces.ICosmeticProductService cosmeticProductService;
        private BusinessLogic.Interfaces.ISaloonService saloonService;

        private DataAccess.UnitOfWork unitOfWork = new DataAccess.UnitOfWork();

        private List<Queue> queue;

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

            bankService = new BusinessLogic.BankService(unitOfWork.Banks);
            cosmeticProductService = new BusinessLogic.CosmeticProductService(unitOfWork.CosmeticProducts);
            saloonService = new BusinessLogic.SaloonService(unitOfWork.Saloons);

            queue = new List<Queue>();
        }

        public void CheckQueue() {
            foreach (var product in queue.ToArray())
            {
                if ((product.created + product.product.DeliveryTime) < DateTime.Now)
                {
                    queue.Remove(product);
                    saloonService.AddProduct(product.product, saloonService.GetById(saloonId));
                }
            }
        }

        public List<Models.CosmeticProduct> GetAllProducts()
        {
            CheckQueue();
            return saloonService.GetProductsBySaloon(saloonService.GetById(saloonId));
        }

        public void AddProduct(Models.CosmeticProduct cosmeticProduct, TimeSpan storageTime)
        {
            Models.CosmeticProduct res = new Models.CosmeticProduct();

            foreach (var asm in AppDomain.CurrentDomain.GetAssemblies())
            {
                Type type = asm.GetType("BeautySaloon.Models." + cosmeticProduct.Type.ToString());
                if (type != null)
                    res = (Models.CosmeticProduct)Activator.CreateInstance(type);
            }

            cosmeticProduct.Quantity = 100;
            cosmeticProduct.ProductionTime = DateTime.Now;

            res.id = cosmeticProduct.id;
            res.MinimalQuantity = cosmeticProduct.MinimalQuantity;
            res.Name = cosmeticProduct.Name;
            res.Price = cosmeticProduct.Price;
            res.ProductionTime = cosmeticProduct.ProductionTime;
            res.Quantity = cosmeticProduct.Quantity;
            res.ServiceType = cosmeticProduct.ServiceType;
            res.Type = cosmeticProduct.Type;
            res.DeliveryTime = cosmeticProduct.DeliveryTime;

            if (res is Models.IExpiration)
            {
                ((Models.IExpiration)res).StorageTime = storageTime;
            }
            bankService.AddProduct(res, bankService.GetById(bankId));
        }

        public void OrderProduct(Models.CosmeticProduct cosmeticProduct, int quantity)
        {
            queue.Add(new Queue { product = bankService.Sell(cosmeticProduct, quantity, bankService.GetById(bankId)), created = DateTime.Now });
        }

        public void OrderNeeded()
        {
            foreach (var product in bankService.ExecuteOrder(saloonService.FormOrder(saloonService.GetById(saloonId)), bankService.GetById(bankId)))
            {
                queue.Add(new Queue { product = product, created = DateTime.Now });
            }
        }

        public List<Models.Services> GetServices()
        {
            return cosmeticProductService.GetServices();
        }

        public List<Models.ProductTypes> GetTypes()
        {
            return cosmeticProductService.GetTypes();
        }

        public List<Models.CosmeticProduct> GetByService(string name)
        {
            CheckQueue();
            return saloonService.GetProductsByService(saloonService.GetById(saloonId), (Models.Services)Enum.Parse(typeof(Models.Services), name));
        }
        public List<Models.CosmeticProduct> GetBankProducts()
        {
            return cosmeticProductService.GetByBank(bankService.GetById(bankId));
        }
        public List<Models.CosmeticProduct> GetNeededProducts()
        {
            return saloonService.GetAllNeededProducts(saloonService.GetById(saloonId));
        }
        public void UpdateProduct(Models.CosmeticProduct cosmeticProduct, TimeSpan storageTime)
        {
            Models.CosmeticProduct res = new Models.CosmeticProduct();

            foreach (var asm in AppDomain.CurrentDomain.GetAssemblies())
            {
                Type type = asm.GetType("BeautySaloon.Models." + cosmeticProduct.Type.ToString());
                if (type != null)
                    res = (Models.CosmeticProduct)Activator.CreateInstance(type);
            }

            cosmeticProduct.Quantity = 100;
            cosmeticProduct.DeliveryTime = TimeSpan.FromSeconds(1);
            cosmeticProduct.ProductionTime = DateTime.Now;

            res.id = cosmeticProduct.id;
            res.MinimalQuantity = cosmeticProduct.MinimalQuantity;
            res.Name = cosmeticProduct.Name;
            res.Price = cosmeticProduct.Price;
            res.ProductionTime = cosmeticProduct.ProductionTime;
            res.Quantity = cosmeticProduct.Quantity;
            res.ServiceType = cosmeticProduct.ServiceType;
            res.Type = cosmeticProduct.Type;
            res.DeliveryTime = cosmeticProduct.DeliveryTime;

            if (res is Models.IExpiration)
            {
                ((Models.IExpiration)res).StorageTime = storageTime;
            }

            cosmeticProductService.Update(res);
            saloonService.UpdateStorage(res, saloonService.GetById(saloonId));
        }
    }
}
