using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;

namespace MEF_Samples
{
    class LazyLoading_Sample
    {
        static void Main(string[] args)
        {
            MEF_Consumer mef_Consumer = new MEF_Consumer();
            ComposeParts(mef_Consumer);

            foreach (var item in mef_Consumer.countryRules)
            {
                Console.WriteLine(item.NationalGame());
            }

            Console.ReadLine();
        }

        static void ComposeParts(object consumer)
        {
            AssemblyCatalog catalog = new AssemblyCatalog(System.Reflection.Assembly.GetExecutingAssembly());
            CompositionContainer compositionContainer = new CompositionContainer(catalog);
            compositionContainer.ComposeParts(consumer);
            //compositionContainer.GetExportedValue<"">
        }
    }

    class MEF_Consumer
    {
        [ImportMany]
        public List<ICountryRule> countryRules;
    }

    interface ICountryRule
    {
        string NationalGame();
    }

    [Export(typeof(ICountryRule))]
    [ExportMetadata("countryName", "India")]
    class India : ICountryRule
    {
        public string NationalGame()
        {
            return "Hockey";
        }
    }

    [Export(typeof(ICountryRule))]
    [ExportMetadata("countryName", "England")]
    class England : ICountryRule
    {
        public string NationalGame()
        {
            return "Cricket";
        }
    }
}
