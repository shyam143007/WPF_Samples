using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using Entities;

namespace WCF_Services
{
    [ServiceContract]
    public interface IPersonService
    {
        [OperationContract]
        //[FaultContract(typeof(CustomException))]
        List<Person> GetPersons();

        [OperationContract]
        int GetCount();

        [OperationContract]
        int GetConsistency();
    }
}
