using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using WCF_Services;

namespace Service_Starter
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(PersonService));
            host.Open();
            Console.WriteLine("Enter any key to stop the service.");
            Console.ReadLine();
            host.Close();
        }
    }
}
