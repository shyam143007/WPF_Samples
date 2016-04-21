using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using Client_Entities;
using System.ComponentModel.Composition;

namespace Client_Proxy
{

    [ServiceContract]
    public interface IPersonService
    {
        [OperationContract]
        List<Person> GetPersons();

        [OperationContract]
        int GetCount();

        [OperationContract]
        int GetConsistency();
    }
}
