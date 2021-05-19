using System;
using System.Collections.Generic;
using System.Text;

namespace BeautySaloon.DataAccess
{
    public class BeautySaloonInitializer : System.Data.Entity.DropCreateDatabaseAlways<BeautySaloonDbContext>
    {
        protected override void Seed(BeautySaloonDbContext context)
        {
            List<Entities.ProductType> productTypes = new List<Entities.ProductType>
            {
                new Entities.ProductType{ID=1, Name="Shampoo", MinimalQuantity=100 },
                new Entities.ProductType{ID=2, Name="Gel", MinimalQuantity=100     , StorageTime=TimeSpan.Parse("10:00:00")},
                new Entities.ProductType{ID=3, Name="Balm", MinimalQuantity=50     , StorageTime=TimeSpan.Parse("10:00:00")},
                new Entities.ProductType{ID=4, Name="Pomade", MinimalQuantity=100  , StorageTime=TimeSpan.Parse("10:00:00")},
                new Entities.ProductType{ID=5, Name="Cream", MinimalQuantity=50    , StorageTime=TimeSpan.Parse("00:00:05")},
            };

            context.ProductTypes.AddRange(productTypes);

            List<Entities.CosmeticProduct> products = new List<Entities.CosmeticProduct>
            {
                new Entities.CosmeticProduct{ID=1, ProductTypeID=1, Name="CoolShampoo", Price=10.0f, Quantity=1000, DeliveryTime=TimeSpan.Parse("00:00:01"), ProductionTime=DateTime.Now},
                new Entities.CosmeticProduct{ID=2, ProductTypeID=2, Name="CoolGel", Price=10.0f, Quantity=1000, DeliveryTime=TimeSpan.Parse("00:00:01"), ProductionTime=DateTime.Now},
                new Entities.CosmeticProduct{ID=3, ProductTypeID=3, Name="CoolBalm", Price=10.0f, Quantity=1000, DeliveryTime=TimeSpan.Parse("00:00:01"), ProductionTime=DateTime.Now},
                new Entities.CosmeticProduct{ID=4, ProductTypeID=4, Name="CoolPomade", Price=10.0f, Quantity=1000, DeliveryTime=TimeSpan.Parse("00:00:01"), ProductionTime=DateTime.Now},
                new Entities.CosmeticProduct{ID=5, ProductTypeID=5, Name="CoolCream", Price=10.0f, Quantity=1000, DeliveryTime=TimeSpan.Parse("00:00:01"), ProductionTime=DateTime.Now},
                                             
                new Entities.CosmeticProduct{ID=6, ProductTypeID=1, Name="CoolShampoo", Price=10.0f, Quantity=100, DeliveryTime=TimeSpan.Parse("00:00:01"), ProductionTime=DateTime.Now},
                new Entities.CosmeticProduct{ID=7, ProductTypeID=2, Name="CoolGel", Price=10.0f, Quantity=7, DeliveryTime=TimeSpan.Parse("00:00:01"), ProductionTime=DateTime.Now},
                new Entities.CosmeticProduct{ID=8, ProductTypeID=3, Name="CoolBalm", Price=10.0f, Quantity=9, DeliveryTime=TimeSpan.Parse("00:00:01"), ProductionTime=DateTime.Now},
                new Entities.CosmeticProduct{ID=9, ProductTypeID=4, Name="CoolPomade", Price=10.0f, Quantity=100, DeliveryTime=TimeSpan.Parse("00:00:01"), ProductionTime=DateTime.Now},
                new Entities.CosmeticProduct{ID=10, ProductTypeID=5, Name="CoolCream", Price=10.0f, Quantity=100, DeliveryTime=TimeSpan.Parse("00:00:01"), ProductionTime=DateTime.Now}
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
                new Entities.BankProduct{ID=1, BankID=1, CosmeticProductID=1},
                new Entities.BankProduct{ID=1, BankID=1, CosmeticProductID=2},
                new Entities.BankProduct{ID=1, BankID=1, CosmeticProductID=3},
                new Entities.BankProduct{ID=1, BankID=1, CosmeticProductID=4},
                new Entities.BankProduct{ID=1, BankID=1, CosmeticProductID=5}
            };

            context.BankProducts.AddRange(bankProducts);

            List<Entities.SaloonProduct> saloonProducts = new List<Entities.SaloonProduct>
            {
                new Entities.SaloonProduct{ID=1, SaloonID=1, CosmeticProductID=6},
                new Entities.SaloonProduct{ID=1, SaloonID=1, CosmeticProductID=7},
                new Entities.SaloonProduct{ID=1, SaloonID=1, CosmeticProductID=8},
                new Entities.SaloonProduct{ID=1, SaloonID=1, CosmeticProductID=9},
                new Entities.SaloonProduct{ID=1, SaloonID=1, CosmeticProductID=10}
            };

            context.SaloonProducts.AddRange(saloonProducts);

            base.Seed(context);
        }
    }
}
