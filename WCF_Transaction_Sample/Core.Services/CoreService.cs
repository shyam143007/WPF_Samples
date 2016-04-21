using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Contracts;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition;

namespace Core.Services
{
    [Export(typeof(ICoreFactory))]
    public class CoreService : ICoreFactory
    {
        public static CompositionContainer Container { get; set; }
        public T CreateClient<T>()
        {
            return Container.GetExportedValue<T>();
        }
    }
}
