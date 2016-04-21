using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Contracts;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;

namespace Core.Services
{
    [Export(typeof(ICoreDataFactory))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class CoreDataRepoService : ICoreDataFactory
    {
        public static CompositionContainer Container { get; set; }
        public T GetDataRepository<T>()
        {
            return Container.GetExportedValue<T>();
        }
    }
}
