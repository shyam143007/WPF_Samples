using Mvvm_Patternn.Models;
using Mvvm_Patternn.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Mvvm_Patternn.ViewModel
{
    public class Company_ViewModel
    {
        private List<Company> _companies;
        public List<Company> Companies
        {
            get
            {
                return _companies;
            }
            set
            {
                _companies = value;
            }
        }

        private Company _selectedCompany;
        public Company SelectedCompany
        {
            get
            {
                return _selectedCompany;
            }
            set
            {
                _selectedCompany = value;
                RaiseCompanyChanged();
            }
        }

        private ICommand addCommand;

        public ICommand AddCommand
        {
            get
            {
                if (addCommand == null)
                {
                    addCommand = new AddDelegateCommand(Add_Execute, new Func<object, bool>(Add_CanExecute));
                }
                return addCommand;
            }
            //set { addCommand = value; }
        }


        public Company_ViewModel()
        {
            _companies = new List<Company>()
            {
                new Company()
                {
                    Id =1,
                    Name ="CodeProject",
                },
                new Company()
                {
                    Id =2,
                    Name ="W3Schools",
                }
            };
        }

        private void RaiseCompanyChanged()
        {
            if (CompanyChangedEvent != null)
                CompanyChangedEvent(SelectedCompany);
        }

        public delegate void CompanyChangedHandler(Company company);
        public static event CompanyChangedHandler CompanyChangedEvent;

        int SampleMethod()
        {
            try
            {
                return 1;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                Console.Write("executed finally");
            }
        }

        private bool Add_CanExecute(object parameter)
        {
            return true;
        }

        private void Add_Execute(object parameter)
        {

        }

        //private class CompanyChangedCommand : ICommand
        //{
        //    public event EventHandler CanExecuteChanged;

        //    public bool CanExecute(object parameter)
        //    {
        //        return true;
        //    }

        //    public void Execute(object parameter)
        //    {
        //        Product_ViewModel product_ViewModel = new Product_ViewModel();
        //        product_ViewModel.Products = null;
        //        Company company = parameter as Company;

        //        if (company.Id == 1)
        //        {
        //            product_ViewModel.Products = new List<Product>()
        //            {
        //                new Product() { Id=1, Name="Winforms app" },
        //                new Product() { Id=2, Name="Web app" }
        //            };
        //        }
        //        else if (company.Id == 2)
        //        {
        //            product_ViewModel.Products = new List<Product>()
        //            {
        //                new Product() { Id=1, Name="Html" },
        //                new Product() { Id=2, Name="Css" }
        //            };
        //        }
        //    }
        //}
        //private ICommand _companyChanged;
        //public ICommand CompanyChanged
        //{
        //    get
        //    {
        //        if (_companyChanged == null)
        //            _companyChanged = new CompanyChangedCommand();
        //        return _companyChanged;
        //    }
        //    set { _companyChanged = value; }
        //}
    }
}
