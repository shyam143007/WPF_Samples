using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Samples
{
    /// <summary>
    /// Interaction logic for DataTemplate_Sample.xaml
    /// </summary>
    public partial class DataTemplate_Sample : Window, INotifyPropertyChanged
    {
        List<Person> _persons;

        public event PropertyChangedEventHandler PropertyChanged;

        public List<Person> Persons
        {
            get
            {
                return _persons;
            }
            set
            {
                _persons = value;
                OnPropertyChanged("Persons");
            }
        }

        public DataTemplate_Sample()
        {
            InitializeComponent();

            this.DataContext = this;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            List<Person> persons = new List<Person>()
            {
               new Person() { Name="Sai", Age=27 },
               new Person() { Name="Shyam", Age=25 }
            };
            Persons = persons;
        }

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
