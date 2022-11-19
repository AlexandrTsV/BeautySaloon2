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
        private Commands.Commands commands;
        public event PropertyChangedEventHandler PropertyChanged;
        private ObservableCollection<Service> services;
        private ObservableCollection<ProductType> productTypes;
        private Service selectedService;
        private ProductType selectedProductType;
        public ObservableCollection<Service> Services { get { return services; } set { services = value; OnPropertyChanged("services"); } }
        public Service SelectedService { get { return selectedService; } set { selectedService = value;
                ServiceType = (Models.Services)Enum.Parse(typeof(Models.Services), value.Name); OnPropertyChanged("selectedService"); } }
        public ObservableCollection<ProductType> ProductTypes { get { return productTypes; } set { productTypes = value; OnPropertyChanged("productTypes"); } }
        public ProductType SelectedProductType { get { return selectedProductType; } set { selectedProductType = value; OnPropertyChanged("selectedProductType"); } }

        public DelegateCommand ToExpired { get; set; }
        public int Seconds { get; set; }
        public int Hours { get; set; }
        public int Minutes { get; set; }
        public int DeliveryHours   { get; set; }
        public int DeliveryMinutes { get; set; }
        public int DeliverySeconds { get; set; }
        private void InitializeFields()
        {
            commands = new Commands.Commands();

            ToExpired = new DelegateCommand(a =>
            {
                Type = Models.ProductTypes.CosmeticProductExpiration;
                commands.UpdateProduct(this, new TimeSpan(Hours, Minutes, Seconds));
                ToExpired.RaiseCanExecuteChanged();
            },
            a =>
            {
                if (Type != Models.ProductTypes.CosmeticProductLongTerm) return false;
                else { return true; };
            });

            Services = new ObservableCollection<Service>();
            foreach (var item in commands.GetServices())
            {
                Services.Add(new Service { Name = item.ToString() });
            }
            SelectedService = Services[0];

            ProductTypes = new ObservableCollection<ProductType>();
            foreach (var item in commands.GetTypes())
            {
                ProductTypes.Add(new ProductType { Name = item.ToString() });
            }
            SelectedProductType = ProductTypes[0];
        }
        public CosmeticProductVM()
        {
            Name = "Test1";
            Price = 5;
            Type = 0;
            ServiceType = 0;

            InitializeFields();
        }

        public CosmeticProductVM(Models.CosmeticProduct cosmeticProduct)
        {
            id = cosmeticProduct.id;
            Name = cosmeticProduct.Name;
            Price = cosmeticProduct.Price;
            Type = cosmeticProduct.Type;
            ServiceType = cosmeticProduct.ServiceType;
            Quantity = cosmeticProduct.Quantity;
            MinimalQuantity = cosmeticProduct.MinimalQuantity;
            DeliveryTime = cosmeticProduct.DeliveryTime;

            InitializeFields();
        }
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
