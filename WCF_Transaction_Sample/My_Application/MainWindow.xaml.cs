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
using System.Transactions;
using System.ComponentModel.Composition.Hosting;
using ClientServiceManagers.Contracts;
using ClientServiceManagers.Entities;
using Core.Services;
using Core.Contracts;
using System.ComponentModel;
using log4net;
using log4net.Core;

namespace My_Application
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        #region Variables and Properties

        List<Person> _persons = null;
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

        #endregion

        #region ctor
        public MainWindow()
        {
            InitializeComponent();

            //AssemblyCatalog catalog = new AssemblyCatalog(System.Reflection.Assembly.GetExecutingAssembly());
            //CompositionContainer container = new CompositionContainer(catalog);
            this.DataContext = this;
        }
        #endregion

        #region Window Events

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                ICoreFactory factory = CoreService.Container.GetExportedValue<ICoreFactory>();

                IPersonService proxy = factory.CreateClient<IPersonService>();
                Persons = proxy.GetPersons();
                Logger.Log("persons loaded", Logger.Level.Info);
            }
            catch (Exception ex)
            {
                Logger.Log(ex.Message + Environment.NewLine + ex.StackTrace, Logger.Level.Error);
                MessageBox.Show(ex.Message + Environment.NewLine + ex.StackTrace + Environment.NewLine.ToString());
            }
        }

        private void AddPerson_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            using (TransactionScope ts = new TransactionScope())
            {
                try
                {
                    Person person = new Person() { Name = txtName.Text };
                    ICoreFactory factory = CoreService.Container.GetExportedValue<ICoreFactory>();
                    IPersonService proxy = factory.CreateClient<IPersonService>();

                    int value = proxy.AddPerson(person);
                    ts.Complete();
                }
                catch (Exception ex)
                {
                    ts.Dispose();
                    MessageBox.Show(ex.Message + Environment.NewLine + ex.StackTrace);
                }
            }
        }

        #endregion

        #region Property Change Handlers

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }

    //public class MEF_Container
    //{
    //    public static CompositionContainer Container { get; set; }
    //}

    public static class Logger
    {
        public enum Level
        {
            Debug = 0,
            Error,
            Fatal,
            Info
        }

        private static ILog _logger;

        public static void Configure()
        {
            log4net.Config.XmlConfigurator.Configure();
            _logger = log4net.LogManager.GetLogger("Log");
        }

        public static void Log(string message, Level logLevel)
        {
            switch (logLevel)
            {
                case Level.Debug:
                    _logger.Debug(message);
                    break;
                case Level.Error:
                    _logger.Error(message);
                    break;
                case Level.Fatal:
                    _logger.Fatal(message);
                    break;
                case Level.Info:
                    _logger.Info(message);
                    break;
            }
        }
    }
}
