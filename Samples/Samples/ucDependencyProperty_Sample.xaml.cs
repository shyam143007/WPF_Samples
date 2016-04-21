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
    /// Interaction logic for ucDependencyProperty_Sample.xaml
    /// </summary>
    public partial class ucDependencyProperty_Sample : UserControl
    {
        public ucDependencyProperty_Sample()
        {
            InitializeComponent();
        }

        public string SetText
        {
            get
            {
                return GetValue(SetTextProperty).ToString();
            }
            set
            {
                SetValue(SetTextProperty, value);
            }
        }

        public static readonly DependencyProperty SetTextProperty = DependencyProperty.Register("SetText", typeof(string), typeof(ucDependencyProperty_Sample), new PropertyMetadata("", OnSetTextChanged));

        public static void OnSetTextChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            ucDependencyProperty_Sample sample = sender as ucDependencyProperty_Sample;
            sample.SetTextChanged(e);
        }

        private void SetTextChanged(DependencyPropertyChangedEventArgs e)
        {
            tblName.Text = e.NewValue.ToString();
        }
    }
}