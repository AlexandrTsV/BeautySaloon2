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
            Name = "Test1";
            Price = 5;
            Type = 0;
        }

        public CosmeticProductVM(Models.CosmeticProduct cosmeticProduct)
        {
            id = cosmeticProduct.id;
            Name = cosmeticProduct.Name;
            Price = cosmeticProduct.Price;
            Type = cosmeticProduct.Type;
            Quantity = cosmeticProduct.Quantity;
        }
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
