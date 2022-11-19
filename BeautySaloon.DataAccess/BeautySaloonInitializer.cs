using System;
using System.Collections.Generic;
using System.Text;

namespace BeautySaloon.DataAccess
{
    public class BeautySaloonInitializer : System.Data.Entity.DropCreateDatabaseAlways<BeautySaloonDbContext>
    {
        protected override void Seed(BeautySaloonDbContext context)
        {
            List<Entities.Service> services = new List<Entities.Service>
            {
                new Entities.Service{ ID = 1, Name="Face" },
                new Entities.Service{ ID = 2, Name="Body" },
                new Entities.Service{ ID = 3, Name="Hair" },
                new Entities.Service{ ID = 4, Name="Lips" }
            };

            context.Services.AddRange(services);

            List<Entities.ProductType> productTypes = new List<Entities.ProductType>
            {
                new Entities.ProductType{ID=1, Name="CosmeticProduct",  },
                new Entities.ProductType{ID=2, Name="CosmeticProductExpiration",    },
                new Entities.ProductType{ID=3, Name="CosmeticProductLongTerm",   }
            };

            context.ProductTypes.AddRange(productTypes);

            List<Entities.CosmeticProduct> products = new List<Entities.CosmeticProduct>
            {
                new Entities.CosmeticProduct{ID=1, ProductTypeID=1, ServiceID = 1,  Name="CoolShampoo", Price=10.0f, MinimalQuantity=100, DeliveryTime=TimeSpan.Parse("00:00:05"), ProductionTime=DateTime.Now},
                new Entities.CosmeticProduct{ID=2, ProductTypeID=3, ServiceID = 1,  Name="CoolGel", Price=10.0f,     MinimalQuantity=100,    StorageTime=TimeSpan.Parse("10:00:00"), DeliveryTime=TimeSpan.Parse("00:00:05"), ProductionTime=DateTime.Now},
                new Entities.CosmeticProduct{ID=3, ProductTypeID=3, ServiceID = 2,  Name="CoolBalm", Price=10.0f,    MinimalQuantity=50,     StorageTime=TimeSpan.Parse("10:00:00"), DeliveryTime=TimeSpan.Parse("00:00:05"), ProductionTime=DateTime.Now},
                new Entities.CosmeticProduct{ID=4, ProductTypeID=3, ServiceID = 2,  Name="CoolPomade", Price=10.0f,  MinimalQuantity=100,  StorageTime=TimeSpan.Parse("10:00:00"), DeliveryTime=TimeSpan.Parse("00:00:05"), ProductionTime=DateTime.Now},
                new Entities.CosmeticProduct{ID=5, ProductTypeID=2, ServiceID = 2,  Name="CoolCream", Price=10.0f,   MinimalQuantity=50,    StorageTime=TimeSpan.Parse("00:00:05"), DeliveryTime=TimeSpan.Parse("00:00:05"), ProductionTime=DateTime.Now}
                                             
                //new Entities.CosmeticProduct{ID=6, ProductTypeID=1, ServiceID = 1, Name="CoolShampoo", Price=10.0f, MinimalQuantity=100,DeliveryTime=TimeSpan.Parse("00:00:01"), ProductionTime=DateTime.Now},
                //new Entities.CosmeticProduct{ID=7, ProductTypeID=3, ServiceID = 1, Name="CoolGel", Price=10.0f,     MinimalQuantity=100,StorageTime=TimeSpan.Parse("10:00:00"), DeliveryTime=TimeSpan.Parse("00:00:01"), ProductionTime=DateTime.Now},
                //new Entities.CosmeticProduct{ID=8, ProductTypeID=3, ServiceID = 2, Name="CoolBalm", Price=10.0f,    MinimalQuantity=50, StorageTime=TimeSpan.Parse("10:00:00"), DeliveryTime=TimeSpan.Parse("00:00:01"), ProductionTime=DateTime.Now},
                //new Entities.CosmeticProduct{ID=9, ProductTypeID=3, ServiceID = 2, Name="CoolPomade", Price=10.0f,  MinimalQuantity=100,StorageTime=TimeSpan.Parse("10:00:00"), DeliveryTime=TimeSpan.Parse("00:00:01"), ProductionTime=DateTime.Now},
                //new Entities.CosmeticProduct{ID=10,ProductTypeID=2, ServiceID = 2, Name="CoolCream", Price=10.0f,   MinimalQuantity=50, StorageTime=TimeSpan.Parse("00:00:05"), DeliveryTime=TimeSpan.Parse("00:00:01"), ProductionTime=DateTime.Now}
            };

            context.CosmeticProducts.AddRange(products);

            List<Entities.Bank> banks = new List<Entities.Bank>
            {
                new Entities.Bank{ID=1}
            };

            context.Banks.AddRange(banks);

            List<Entities.Saloon> saloons = new List<Entities.Saloon>
            {
                new Entities.Saloon{ID=1}
            };

            context.Saloons.AddRange(saloons);

            List<Entities.BankProduct> bankProducts = new List<Entities.BankProduct>
            {
                new Entities.BankProduct{ID=1, BankID=1, CosmeticProductID=1, Quantity=1000},
                new Entities.BankProduct{ID=1, BankID=1, CosmeticProductID=2, Quantity=1000},
                new Entities.BankProduct{ID=1, BankID=1, CosmeticProductID=3, Quantity=1000},
                new Entities.BankProduct{ID=1, BankID=1, CosmeticProductID=4, Quantity=1000},
                new Entities.BankProduct{ID=1, BankID=1, CosmeticProductID=5, Quantity=1000}
            };                                                             

            context.BankProducts.AddRange(bankProducts);

            List<Entities.SaloonProduct> saloonProducts = new List<Entities.SaloonProduct>
            {
                new Entities.SaloonProduct{ID=1, SaloonID=1, CosmeticProductID=1 , Quantity=1000},
                new Entities.SaloonProduct{ID=1, SaloonID=1, CosmeticProductID=2 , Quantity=7},
                new Entities.SaloonProduct{ID=1, SaloonID=1, CosmeticProductID=3 , Quantity=9},
                new Entities.SaloonProduct{ID=1, SaloonID=1, CosmeticProductID=4 , Quantity=1000},
                new Entities.SaloonProduct{ID=1, SaloonID=1, CosmeticProductID=5, Quantity=1000}
            };

            context.SaloonProducts.AddRange(saloonProducts);

            base.Seed(context);
        }
    }
}
