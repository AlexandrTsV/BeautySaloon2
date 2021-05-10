using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace BeautySaloon.Views
{
    public class CosmeticProductVM : Models.CosmeticProduct, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public CosmeticProductVM()
        {
            name = "Test1";
            price = 5;
            type = "TestType";
        }

        public CosmeticProductVM(Models.CosmeticProduct cosmeticProduct)
        {
            id = cosmeticProduct.id;
            name = cosmeticProduct.name;
            price = cosmeticProduct.price;
            type = cosmeticProduct.type;
            quantity = cosmeticProduct.quantity;
        }
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
