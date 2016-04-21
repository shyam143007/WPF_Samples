using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using System.ServiceModel;

namespace WCF_Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, ConcurrencyMode = ConcurrencyMode.Single)]
    public class PersonService : IPersonService
    {
        int count = 0;
        public List<Person> GetPersons()
        {
            try
            {
                List<Person> persons = new List<Person>()
                                {
                                    new Person() { Id=Guid.Parse("35333bbb-3e18-49de-8517-710ec1e66641"), Name="Ram", Permission=PermissionType.User }
                                };
                //int zero = 0;
                //int a = 10 / zero;
                throw new CustomException("custom Exception");
                return persons;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int GetCount()
        {
            int currentCount = count;
            count++;
            return currentCount;
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public int GetConsistency()
        {
            try
            {
                count = 1;
                int val = count / 0;
                return count;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }


    public class CustomException : ApplicationException
    {
        public CustomException(string message) : base(message)
        {

        }

        public CustomException() : base()
        {

        }
    }
}
