using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace BeautySaloon.Views
{
    public class CosmeticProductVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public Models.CosmeticProduct cosmeticProduct;

        public string Name { get { return cosmeticProduct.name; } }
        public double Price { get { return cosmeticProduct.price; } }
        public string Type { get { return cosmeticProduct.type; } }
        public int Quantity { get { return cosmeticProduct.quantity;  } }

        public CosmeticProductVM()
        {
            cosmeticProduct = new Models.CosmeticProduct() { name = "Test1", price = 5, type = "TestType" };
        }

        public CosmeticProductVM(Models.CosmeticProduct cosmeticProduct)
        {
            this.cosmeticProduct = cosmeticProduct;
        }
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
