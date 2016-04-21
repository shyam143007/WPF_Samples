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

namespace Samples
{
    /// <summary>
    /// Interaction logic for CommandBindings_Sample.xaml
    /// </summary>
    public partial class CommandBindings_Sample : Window
    {
        string firstString = "string1";
        string secondString;
        public CommandBindings_Sample()
        {
            InitializeComponent();
            secondString = firstString;
            char[] tempChar = secondString.ToCharArray();
            Array.Reverse(tempChar);
            string reverse = new string(tempChar);
            firstString = "string2";
        }

        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            this.Close();
        }

        private void AlertCommand(object sender, ExecutedRoutedEventArgs e)
        {
            GC.Collect();
            MessageBox.Show("Hello");
        }

        public void finalize()
        {

        }
    }
}
