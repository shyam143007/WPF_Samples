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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Client_Entities;
using Client_Proxy;
using System.ComponentModel.Composition.Hosting;

namespace SSP1Application
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                IPersonService proxy = ContainerClass.GetObject<IPersonService>();
                //List<Person> persons = proxy.GetPersons();
                Console.WriteLine(proxy.GetCount());
                Console.WriteLine(proxy.GetCount());
            }
            catch (Exception ex)
            {

            }
        }

        private void GoToService_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {
                IPersonService proxy = ContainerClass.GetObject<IPersonService>();
                int val = proxy.GetConsistency();
                MessageBox.Show(val.ToString());
            }
            catch
            {

            }
        }
    }
}