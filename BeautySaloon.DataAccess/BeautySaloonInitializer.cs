using System;
using System.Collections.Generic;
using System.Text;

namespace BeautySaloon.DataAccess
{
    public class BeautySaloonInitializer : System.Data.Entity.DropCreateDatabaseAlways<BeautySaloonDbContext>
    {
        protected override void Seed(BeautySaloonDbContext context)
        {
            List<Entities.CosmeticProduct> products = new List<Entities.CosmeticProduct>
            {
                new Entities.CosmeticProduct{id=1, type="Shampoo", name="CoolShampoo", price=10.0f, quantity=1000, deliveryTime=TimeSpan.Parse("00:00:01"), productionTime=DateTime.Now},
                new Entities.CosmeticProduct{id=2, type="Gel", name="CoolGel", price=10.0f, quantity=1000, deliveryTime=TimeSpan.Parse("00:00:01"), productionTime=DateTime.Now},
                new Entities.CosmeticProduct{id=3, type="Balm", name="CoolBalm", price=10.0f, quantity=1000, deliveryTime=TimeSpan.Parse("00:00:01"), productionTime=DateTime.Now},
                new Entities.CosmeticProduct{id=4, type="Pomade", name="CoolPomade", price=10.0f, quantity=1000, deliveryTime=TimeSpan.Parse("00:00:01"), productionTime=DateTime.Now},
                new Entities.CosmeticProduct{id=5, type="Cream", name="CoolCream", price=10.0f, quantity=1000, deliveryTime=TimeSpan.Parse("00:00:01"), productionTime=DateTime.Now},

                new Entities.CosmeticProduct{id=6, type="Shampoo", name="CoolShampoo", price=10.0f, quantity=100, deliveryTime=TimeSpan.Parse("00:00:01"), productionTime=DateTime.Now},
                new Entities.CosmeticProduct{id=7, type="Gel", name="CoolGel", price=10.0f, quantity=7, deliveryTime=TimeSpan.Parse("00:00:01"), productionTime=DateTime.Now},
                new Entities.CosmeticProduct{id=8, type="Balm", name="CoolBalm", price=10.0f, quantity=9, deliveryTime=TimeSpan.Parse("00:00:01"), productionTime=DateTime.Now},
                new Entities.CosmeticProduct{id=9, type="Pomade", name="CoolPomade", price=10.0f, quantity=100, deliveryTime=TimeSpan.Parse("00:00:01"), productionTime=DateTime.Now},
                new Entities.CosmeticProduct{id=10, type="Cream", name="CoolCream", price=10.0f, quantity=100, deliveryTime=TimeSpan.Parse("00:00:01"), productionTime=DateTime.Now}
            };

            context.CosmeticProducts.AddRange(products);

            List<Entities.Bank> banks = new List<Entities.Bank>
            {
                new Entities.Bank{id=1}
            };

            context.Banks.AddRange(banks);

            List<Entities.Saloon> saloons = new List<Entities.Saloon>
            {
                new Entities.Saloon{id=1}
            };

            context.Saloons.AddRange(saloons);

            List<Entities.BankProduct> bankProducts = new List<Entities.BankProduct>
            {
                new Entities.BankProduct{id=1, bankId=1, productId=1},
                new Entities.BankProduct{id=1, bankId=1, productId=2},
                new Entities.BankProduct{id=1, bankId=1, productId=3},
                new Entities.BankProduct{id=1, bankId=1, productId=4},
                new Entities.BankProduct{id=1, bankId=1, productId=5}
            };

            context.BankProducts.AddRange(bankProducts);

            List<Entities.SaloonProduct> saloonProducts = new List<Entities.SaloonProduct>
            {
                new Entities.SaloonProduct{id=1, saloonId=1, productId=6},
                new Entities.SaloonProduct{id=1, saloonId=1, productId=7},
                new Entities.SaloonProduct{id=1, saloonId=1, productId=8},
                new Entities.SaloonProduct{id=1, saloonId=1, productId=9},
                new Entities.SaloonProduct{id=1, saloonId=1, productId=10}
            };

            context.SaloonProducts.AddRange(saloonProducts);

            base.Seed(context);
        }
    }
}
