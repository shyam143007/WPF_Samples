using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Services.Services;
using Core.Services;
using ServiceManager.Booter;

namespace Console.AppService
{
    class Program
    {
        static void Main(string[] args)
        {
            CoreDataRepoService.Container = MEFInitializer.Init();
            ServiceHost host = new ServiceHost(typeof(PersonService));
            host.Open();
            System.Console.WriteLine("press Enter to stop the service");
            System.Console.ReadLine();
            host.Close();
        }
    }
}
