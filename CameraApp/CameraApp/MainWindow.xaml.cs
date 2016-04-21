using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

using AForge.Video.DirectShow;
using System.ComponentModel;
using System.IO;
using System.Threading;

namespace CameraApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        #region private-variables

        VideoCaptureDevice webCam = null;
        ImageSourceConverter imageSourceConverter;
        bool takePicture = false;

        #endregion

        #region properties

        public ObservableCollection<FilterInfo> WebCamsCollection { get; set; }

        #endregion

        #region Notify Events

        public event PropertyChangedEventHandler PropertyChanged;

        private void Notify_PropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        #region .net Events

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FilterInfoCollection webCams = null;
            webCams = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            WebCamsCollection = new ObservableCollection<FilterInfo>();
            foreach (FilterInfo currentWebCam in webCams)
            {
                WebCamsCollection.Add(currentWebCam);
            }
            imageSourceConverter = new ImageSourceConverter();
            Notify_PropertyChanged("WebCamsCollection");
        }

        private void Window_Unloaded(object sender, RoutedEventArgs e)
        {
            StopCam();
        }

        private void btnStartStop_Click(object sender, RoutedEventArgs e)
        {
            if (!webCam.IsRunning)
            {
                webCam = new VideoCaptureDevice(((FilterInfo)cmbCams.SelectedItem).MonikerString);
                StartCam();
            }
            else
            {
                StopCam();
            }
        }

        private void cmbCams_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (webCam != null)
                StopCam();
            webCam = new VideoCaptureDevice(cmbCams.SelectedValue.ToString());
            StartCam();
        }

        private void btnTakePicture_Click(object sender, RoutedEventArgs e)
        {
            takePicture = true;
        }

        #endregion

        #region aforge Events

        private void WebCam_NewFrame(object sender, AForge.Video.NewFrameEventArgs eventArgs)
        {
            MemoryStream memoryStream = new MemoryStream();
            System.Drawing.Bitmap img = (System.Drawing.Bitmap)eventArgs.Frame.Clone();
            img.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Bmp);
            memoryStream.Seek(0, SeekOrigin.Begin);

            BitmapImage requiredImage = new BitmapImage();
            requiredImage.BeginInit();
            requiredImage.StreamSource = memoryStream;
            requiredImage.EndInit();
            requiredImage.Freeze();

            if (takePicture)
            {
                takePicture = false;
                img.Save(string.Format(@"C:\Users\shyam\Desktop\Afergo Images\{0}.jpg", System.Guid.NewGuid().ToString()));
            }

            Dispatcher.BeginInvoke(new ThreadStart(delegate
            {
                imgScreen.Source = requiredImage;
            }));
        }

        #endregion

        #region hand-in functions

        void StartCam()
        {
            webCam.NewFrame += WebCam_NewFrame;
            webCam.Start();
        }

        void StopCam()
        {
            if (webCam != null && webCam.IsRunning)
            {
                webCam.NewFrame -= WebCam_NewFrame;
                webCam.Stop();
            }
        }

        #endregion

    }
}
