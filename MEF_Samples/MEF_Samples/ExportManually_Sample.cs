using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;

namespace MEF_Samples
{
    class ExportManually_Sample
    {
        //[ImportMany] 
        //no need of import attribute if we want to load the export manually.
        IEnumerable<ICountryRule> rules;
        static void Main(string[] args)
        {
            ExportManually_Sample sample = new ExportManually_Sample();
            AssemblyCatalog catalog = new AssemblyCatalog(System.Reflection.Assembly.GetExecutingAssembly());
            CompositionContainer container = new CompositionContainer(catalog);
            sample.rules = container.GetExportedValues<ICountryRule>();

            foreach (var item in sample.rules)
            {
                Console.WriteLine(item.NationalGame());
            }
            Console.ReadLine();
        }
    }
}
