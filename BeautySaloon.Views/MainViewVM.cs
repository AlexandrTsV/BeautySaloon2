using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BeautySaloon.Views
{
    public class Service {
        public string Name { get; set; }
    }
    
    public class ProductType
    {
        public string Name { get; set; }
    }
    public class MainViewVM : INotifyPropertyChanged
    {
        private Commands.Commands commands;

        public event PropertyChangedEventHandler PropertyChanged;
        private int orderQuantity;
        private CosmeticProductVM selectedForOrder;
        private ObservableCollection<CosmeticProductVM> saloon;
        private ObservableCollection<CosmeticProductVM> bank;
        private ObservableCollection<CosmeticProductVM> needed;
        private ObservableCollection<Service> services;
        private Service selectedService;
        public int OrderQuantity { get { return orderQuantity; } set { orderQuantity = value; OnPropertyChanged("orderQuantity"); } }
        public ObservableCollection<CosmeticProductVM> Saloon { get { return saloon; } set { saloon = value; OnPropertyChanged("saloon"); } }
        public ObservableCollection<CosmeticProductVM> Bank { get { return bank; } set { bank = value; OnPropertyChanged("bank"); } }
        public ObservableCollection<CosmeticProductVM> Needed { get { return needed; } set { needed = value; OnPropertyChanged("needed"); } }
        public CosmeticProductVM SelectedForOrder { get { return selectedForOrder; } set { if (value != null) selectedForOrder = value; OnPropertyChanged("selectedForOrder"); } }
        public DelegateCommand OrderNeeded { get; set; }
        public DelegateCommand Refresh { get; set; }
        public DelegateCommand OrderProduct { get; set; }
        public DelegateCommand ServiceChanged { get; set; }
        public DelegateCommand AddProduct { get; set; }
        public ObservableCollection<Service> Services { get { return services; } set { services = value; OnPropertyChanged("services"); } }
        public Service SelectedService { get { return selectedService; } set { selectedService = value; Update(); OnPropertyChanged("selectedService"); } }

        private void Update()
        {
            Needed = new ObservableCollection<CosmeticProductVM>(commands.GetNeededProducts().Select(a => new CosmeticProductVM(a)));

            if (SelectedService.Name == "Any") {
                Saloon = new ObservableCollection<CosmeticProductVM>(commands.GetAllProducts().Select(a => new CosmeticProductVM(a)));
            }
            else
            {
                Saloon = new ObservableCollection<CosmeticProductVM>(commands.GetByService(SelectedService.Name).Select(a => new CosmeticProductVM(a)));
            }
            Bank = new ObservableCollection<CosmeticProductVM>(commands.GetBankProducts().Select(a => new CosmeticProductVM(a)));
        }
        public MainViewVM()
        {
            commands = new Commands.Commands();

            OrderQuantity = 10;

            OrderNeeded = new DelegateCommand(new Action<object>(a => {
                commands.OrderNeeded(); 
                Update(); }));

            Refresh = new DelegateCommand(new Action<object>(a => {
                Update();
            }));

            OrderProduct = new DelegateCommand(a =>
            {
                SelectedForOrder.Quantity = 5;
                commands.OrderProduct(SelectedForOrder, OrderQuantity);
                Update();
            });

            AddProduct = new DelegateCommand(a =>
            {
                AddProductView addProductView = new AddProductView();
                addProductView.ShowDialog();
                CosmeticProductVM vm = (CosmeticProductVM)addProductView.DataContext;
                vm.Type = (Models.ProductTypes)Enum.Parse(typeof(Models.ProductTypes), vm.SelectedProductType.Name);
                vm.DeliveryTime = new TimeSpan(vm.DeliveryHours, vm.DeliveryMinutes, vm.DeliverySeconds);
                commands.AddProduct(vm, new TimeSpan(vm.Hours, vm.Minutes, vm.Seconds));
                Update();
            });

            Services = new ObservableCollection<Service>
            {
                new Service {Name = "Any"}
            };
            foreach (var item in commands.GetServices()) {
                Services.Add(new Service { Name = item.ToString() });
            }
            SelectedService = Services[0];

            Update();
        }
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}