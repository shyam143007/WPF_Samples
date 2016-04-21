using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using ClientServiceManagers.Entities;

namespace ClientServiceManagers.Contracts
{
    [ServiceContract]
    public interface IPersonService
    {
        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Mandatory)]
        int AddPerson(Person person);

        [OperationContract]
        List<Person> GetPersons();
    }
}
