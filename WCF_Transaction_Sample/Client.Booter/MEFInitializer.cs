using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition.Hosting;
using Core.Services;
using ClientServiceManagers.Services;

namespace Client.Booter
{
    public class MEFInitializer
    {
        public static CompositionContainer Init()
        {
            //AssemblyCatalog catalog = new AssemblyCatalog(typeof(PersonService).Assembly);
            AggregateCatalog catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(PersonService).Assembly));
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(CoreService).Assembly));
            CompositionContainer container = new CompositionContainer(catalog);
            return container;
        }
    }
}
