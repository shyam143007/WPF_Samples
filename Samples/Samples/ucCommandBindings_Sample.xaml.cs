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

namespace Samples
{
    /// <summary>
    /// Interaction logic for ucCommandBindings_Sample.xaml
    /// </summary>
    public partial class ucCommandBindings_Sample : UserControl
    {
        public ucCommandBindings_Sample()
        {
            InitializeComponent();

            this.DataContext = this;
        }

        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("executed");
        }
    }

    //public static class CustomCommands
    //{
    //    public static readonly RoutedUICommand Exit = new RoutedUICommand("Exit",
    //        "EXIT",
    //        typeof(CustomCommands),
    //        new InputGestureCollection() {
    //            new KeyGesture( Key.A, ModifierKeys.Alt)
    //        });
    //}
}
