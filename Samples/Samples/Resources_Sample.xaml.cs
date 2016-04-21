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

namespace Samples
{
    /// <summary>
    /// Interaction logic for Resources_Sample.xaml
    /// </summary>
    public partial class Resources_Sample : Window, INotifyPropertyChanged
    {
        Color brush;
        Random random = new Random(0);
        RadialGradientBrush radialGradientBrush1;
        public Color Brush
        {
            get
            {
                return brush;
            }
            set
            {
                brush = value;
                OnPropertyChanged("Brush");
            }
        }
        public Resources_Sample()
        {
            InitializeComponent();
            this.DataContext = this;
            //setBrushValue();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        private void btnClickMe_Click(object sender, RoutedEventArgs e)
        {
            setBrushValue();
        }

        void setBrushValue()
        {
            List<byte> colors_1 = GetRGBValues();
            List<byte> colors_2 = GetRGBValues();
            //Brush = Color.FromRgb(red, green, blue);
            radialGradientBrush1 = new RadialGradientBrush(Color.FromRgb(colors_1[0], colors_1[1], colors_1[2]),
                 Color.FromRgb(colors_2[0], colors_2[1], colors_2[2]));
            //radialGradientBrush1.GradientStops.Add(new GradientStop(Colors.Green, 2));
            this.Resources["customBrush"] = radialGradientBrush1;

            
        }

        private List<byte> GetRGBValues()
        {
            byte red = Convert.ToByte(random.Next(0, 255));
            byte green = Convert.ToByte(random.Next(0, 255));
            byte blue = Convert.ToByte(random.Next(0, 255));
            return new List<byte>() { red, green, blue };
        }
    }
}
