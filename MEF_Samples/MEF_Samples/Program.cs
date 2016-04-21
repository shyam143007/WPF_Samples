using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;

namespace MEF_Samples
{
    class Program
    {
        [Import("messageProperty", typeof(string), RequiredCreationPolicy = CreationPolicy.Any)]
        string message;
        //[ImportMany()]
        //IList<string> message = new List<string>();
        static void Main(string[] args)
        {
            Program program = new Program();
            program.Run();
            Console.WriteLine(program.message);
            //foreach (var item in program.message)
            //{
            //    Console.WriteLine(item);
            //}
            Console.ReadLine();
        }

        private void Run()
        {
            AssemblyCatalog catalog = new AssemblyCatalog(System.Reflection.Assembly.GetExecutingAssembly());
            CompositionContainer container = new CompositionContainer(catalog);
            container.ComposeParts(this);
        }
    }

    class MessageBox
    {
        [Export("messageProperty", typeof(string))]
        string MyMessage
        {
            get
            {
                return "this is from messagebox class property mymessage";
            }
        }

        [Export]
        string myMessage2 = "this is from messagebox class variable mymessage2";
    }
}
