using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ComponentModel.Composition;
using ClientServiceManagers.Contracts;
using ClientServiceManagers.Entities;

namespace ClientServiceManagers.Services
{
    [Export(typeof(IPersonService))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class PersonService : ClientBase<IPersonService>, IPersonService
    {
        public new void Close()
        {
            base.Close();
        }

        public new void Abort()
        {
            base.Abort();
        }

        public int AddPerson(Person person)
        {
            try
            {
                return Channel.AddPerson(person);
            }
            catch (ChannelTerminatedException)
            {
                throw;
            }
            catch (FaultException ex)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public List<Person> GetPersons()
        {
            try
            {
                List<Person> persons = Channel.GetPersons();
                return persons;
            }
            catch (FaultException ex)
            {
                throw;
            }
            catch (ChannelTerminatedException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                Close();
            }
        }
    }
}
