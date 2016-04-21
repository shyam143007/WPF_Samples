using Contracts.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using Entities;
using Core.Contracts;
using Core.Services;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using DALManagers.Contracts;


namespace Services.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    [GlobalErrorBehavior(typeof(GlobalErrorHandler))]
    public class PersonService : IPersonService
    {
        [Import]
        ICoreDataFactory dataRepo;
        public PersonService()
        {
            try
            {
                CoreDataRepoService.Container.SatisfyImportsOnce(this);
                //dataRepo = CoreDataRepoService.Container.GetExportedValue<ICoreDataFactory>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public int AddPerson(Person person)
        {
            try
            {
                IPersonDataRepo repository = dataRepo.GetDataRepository<IPersonDataRepo>();
                int result = repository.AddPerson(person);

                int count = 0;
                count = count / 0;
                return result;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + Environment.NewLine + ex.StackTrace);
            }

        }

        public List<Person> GetPersons()
        {
            //throw new NullReferenceException();
            IPersonDataRepo repo = dataRepo.GetDataRepository<IPersonDataRepo>();
            List<Person> persons = repo.GetPersons();
            return persons;
            //return ExecuteFaultHandler(() =>
            // {
            //     int count = 0;
            //     count = count / 0;
            //     IPersonDataRepo repo = dataRepo.GetDataRepository<IPersonDataRepo>();
            //     List<Person> persons = repo.GetPersons();
            //     return persons;
            // });
            //try
            //{
            //    int count = 0;
            //    count = count / 0;
            //    IPersonDataRepo repo = dataRepo.GetDataRepository<IPersonDataRepo>();
            //    List<Person> persons = repo.GetPersons();
            //    return persons;
            //}
            //catch (Exception ex)
            //{
            //    throw new FaultException(ex.Message + Environment.NewLine + ex.StackTrace);
            //    //throw new FaultException<Exception>(ex);
            //}
        }

        public T ExecuteFaultHandler<T>(Func<T> x)
        {
            return x.Invoke();
        }
    }
}
