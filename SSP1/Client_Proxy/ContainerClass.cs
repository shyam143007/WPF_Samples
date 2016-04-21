using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition.Hosting;

namespace Client_Proxy
{
    public class ContainerClass
    {
        public static CompositionContainer GetContainer()
        {
            AssemblyCatalog catalog = new AssemblyCatalog(System.Reflection.Assembly.GetExecutingAssembly());
            CompositionContainer container = new CompositionContainer(catalog);
            return container;
        }

        public static T GetObject<T>()
        {
            CompositionContainer container = GetContainer();
            T _object = container.GetExportedValue<T>();
            return _object;
        }
    }
}
