using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Mvvm_Patternn.Models;
using Mvvm_Patternn.ViewModel;
using System.ComponentModel;

namespace Mvvm_Patternn
{
    public class Product_ViewModel : INotifyPropertyChanged
    {
        private List<Product> _products;
        public List<Product> Products
        {
            get
            {
                return _products;
            }
            set
            {
                _products = value;
                OnPropertyChanged("Products");
            }
        }

        public Product_ViewModel()
        {
            Company_ViewModel.CompanyChangedEvent += Company_ViewModel_CompanyChangedEvent;
        }

        private void Company_ViewModel_CompanyChangedEvent(Company company)
        {
            if (company.Id == 1)
            {
                Products = new List<Product>()
                {
                    new Product() { Id = 1, Name = "WinForms Apps" },
                    new Product() { Id = 2, Name = "Web Apps" }
                };
            }
            else if (company.Id == 2)
            {
                Products = new List<Product>()
                {
                    new Product() { Id=1, Name="Html" },
                    new Product() { Id=2, Name="Css" }
                };
            }
        }

        private ICommand _updateCommand;

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public ICommand UpdateCommand
        {
            get
            {
                if (_updateCommand == null)
                {
                    _updateCommand = new Updater();
                }
                return _updateCommand;
            }
            set
            {
                _updateCommand = value;
            }
        }

        private class Updater : ICommand
        {
            public event EventHandler CanExecuteChanged;

            public bool CanExecute(object parameter)
            {
                return true;
            }

            public void Execute(object parameter)
            {

            }
        }
    }
}
