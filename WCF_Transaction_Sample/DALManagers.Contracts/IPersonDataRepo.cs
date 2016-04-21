using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALManagers.Contracts
{
    public interface IPersonDataRepo
    {
        int AddPerson(Person person);

        List<Person> GetPersons();
    }
}
