using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Mvvm_Patternn.Models;
using Mvvm_Patternn.ViewModel;
using System.ComponentModel;
using Mvvm_Patternn.ViewModel.Commands;

namespace Mvvm_Patternn
{
    public class Product_ViewModel : INotifyPropertyChanged
    {
        #region variables

        private List<Product> _products;
        private Product _selectedProduct;
        private ICommand _updateCommand;

        #endregion

        #region Properties

        public ICommand UpdateCommand
        {
            get
            {
                return _updateCommand;
            }
            set
            {
                _updateCommand = value;
            }
        }

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

        public Product SelectedProduct
        {
            get
            {
                return _selectedProduct;
            }
            set
            {
                _selectedProduct = value;
                OnPropertyChanged("SelectedProduct");
            }
        }

        #endregion

        #region ctor
        public Product_ViewModel()
        {
            UpdateCommand = new UpdateCommand(this);
            Company_ViewModel.CompanyChangedEvent += Company_ViewModel_CompanyChangedEvent;
        }
        #endregion

        #region Custom Event Handlers

        private void Company_ViewModel_CompanyChangedEvent(Company company)
        {
            if (company == null)
            {
                Products = null;
                return;
            }
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

        #endregion

        #region PropertyChanged Events
        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion

        #region Command Methods

        public void UpdateData(object data)
        {
            Product product = data as Product;
        }

        #endregion
    }
}
