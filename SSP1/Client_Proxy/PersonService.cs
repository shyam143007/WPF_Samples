using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client_Entities;
using System.ServiceModel;
using System.ComponentModel.Composition;

namespace Client_Proxy
{
    [Export(typeof(IPersonService))]
    public class PersonService : ClientBase<IPersonService>, IPersonService
    {
        public int GetConsistency()
        {
            try
            {
                return Channel.GetConsistency();
            }
            catch (FaultException ex)
            {
                throw;
            }
            catch(Exception)
            {
                throw;
            }
        }

        public int GetCount()
        {
            try
            {
                return Channel.GetCount();
            }
            catch (FaultException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Person> GetPersons()
        {
            try
            {
                return Channel.GetPersons();
            }
            catch (FaultException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
