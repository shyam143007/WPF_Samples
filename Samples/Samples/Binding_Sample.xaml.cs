using System;
using System.Collections.Generic;
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
using System.ComponentModel;
using System.Globalization;
using DevExpress.Xpf.Grid;

namespace Samples
{
    /// <summary>
    /// Interaction logic for Binding_Sample.xaml
    /// </summary>
    public partial class Binding_Sample : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private List<Person> _persons;

        public List<Person> Persons
        {
            get { return _persons; }
            set
            {
                _persons = value;
                OnPropertyChanged("Persons");
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public Binding_Sample()
        {
            InitializeComponent();

            this.DataContext = this;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Persons = new List<Person>() {
                new Person() { Name = "Akhil", Age = 24 },
                new Person() { Name="NagaChaitanya" , Age=27},
                new Person() {Name="Rana", Age= 32}
            };
        }

        private void imgDelete_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (grdvPersons.FocusedRowHandle >= 0)
            {
                grdvPersons.DeleteRow(grdvPersons.FocusedRowHandle);
            }
        }
    }

    public class Person
    {
        public string Name { get; set; }

        public int Age { get; set; }
    }

    public class DeleteConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Person person = value as Person;
            //string image = "";
            SolidColorBrush brush = Brushes.RoyalBlue;
            if (person != null && person.Age > 24)
            {
                //image = @"F:\WPFSamples\Samples\Samples\Resources\Images\Delete_CM_12x12.png";
                brush = Brushes.Red;
            }
            return brush;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException("From DeleteConverter");
        }
    }
}
