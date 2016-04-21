using DALManagers.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using System.ComponentModel.Composition;
using System.Data;
using System.Data.SqlClient;

namespace DALManagers.Repos
{
    [Export(typeof(IPersonDataRepo))]
    public class PersonDataRepo : IPersonDataRepo
    {
        public int AddPerson(Person person)
        {
            SqlCommand command = null;
            int result = -1;
            try
            {
                command = new SqlCommand();

                command.Connection = ConnectionManager.GetSqlConnection();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "PERSON_ADD";

                command.Parameters.Add("@pName", SqlDbType.VarChar, 255);
                command.Parameters["@pName"].Value = person.Name;

                command.Parameters.Add("@pResult", SqlDbType.Int);
                command.Parameters["@pResult"].Direction = ParameterDirection.Output;

                command.ExecuteNonQuery();

                int.TryParse(command.Parameters["@pResult"].Value.ToString(), out result);

                return result;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                DisposeConnection(command.Connection);
            }
        }

        public List<Person> GetPersons()
        {
            SqlCommand command = null;
            try
            {
                command = new SqlCommand();
                List<Person> persons = null;

                command.Connection = ConnectionManager.GetSqlConnection();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "PERSON_GET";

                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    persons = new List<Person>();
                    while (reader.Read())
                    {
                        Person person = new Person();

                        person.Id = reader["id"] != DBNull.Value ? Convert.ToInt32(reader["id"]) : 0;
                        person.Name = reader["name"] != DBNull.Value ? reader["name"].ToString() : string.Empty;

                        persons.Add(person);
                    }

                    return persons;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                DisposeConnection(command.Connection);
            }
        }

        private void DisposeConnection(SqlConnection connection)
        {
            if (connection != null && connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }
    }
}
