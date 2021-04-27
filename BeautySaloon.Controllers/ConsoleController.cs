using System;
using System.Collections.Generic;

namespace BeautySaloon.Controllers
{
    public class ConsoleController : Interfaces.IController
    {

        private List<Func<string>> actions;
        private BusinessLogic.Interfaces.IBankService bankService;
        private BusinessLogic.Interfaces.ICosmeticProductService cosmeticProductService;
        private BusinessLogic.Interfaces.ISaloonService saloonService;

        private int saloonId = 1;
        private int bankId = 1;

        private void InitializeActions()
        {
            actions = new List<Func<string>>() {
                new Func<string>(() => {
                        string result = "";
                        foreach (var product in cosmeticProductService.GetBySaloonId(saloonId))
                        {
                            result += "Product: " + product.name + "; Quantity: " + product.quantity + "; Type: " + product.GetProductType() + ";\n";
                        }
                        return result;
                    }),
                new Func<string>(() => {
                        string result = "";
                        foreach (var product in saloonService.GetAllNeededProducts(saloonId))
                        { result += "Product: " + product.name + "; Quantity: " + product.quantity + "; Type: " + product.GetProductType() + ";\n"; };
                        return result;
                    }),
                new Func<string>(() => {
                        string result = "";
                        foreach (var product in cosmeticProductService.GetByBankId(bankId))
                        {
                            result += (product.id + ": " + product.name + ", Quantity: " + product.quantity + "\n");
                        }
                        return result;
                    }),
                new Func<string>(() => {
                        foreach (var product in bankService.ExecuteOrder(saloonService.FormOrder(saloonId), bankId)) {
                            saloonService.AddProduct(product, saloonId);
                        }
                        return "Done!";
                    }),
                new Func<string>(() => {
                        Environment.Exit(0);
                        return "Bye!";
                    })
            };
        }
        public ConsoleController()
        {
            bankService = new BusinessLogic.BankService();
            cosmeticProductService = new BusinessLogic.CosmeticProductService();
            saloonService = new BusinessLogic.SaloonService();

            InitializeActions();
        }

        public string Input(string input)
        {
            int actionIndex = int.Parse(input);

            if (actionIndex < actions.Count)
            {
                return actions[actionIndex]();
            }
            return "";
        }
    }
}
