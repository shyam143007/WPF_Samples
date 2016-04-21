using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.Services;
using System.ComponentModel.Composition.Hosting;

namespace ServiceManager.Booter
{
    public class MEFInitializer
    {
        public static CompositionContainer Init()
        {
            AggregateCatalog aggregateCatalog = new AggregateCatalog();
            aggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(DALManagers.Repos.PersonDataRepo).Assembly));
            aggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(Core.Services.CoreDataRepoService).Assembly));
            CompositionContainer container = new CompositionContainer(aggregateCatalog);
            return container;
        }
    }
}
