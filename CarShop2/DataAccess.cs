using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;

namespace CarShop2
{
    class DataAccess
    {
        public List<Cars> GetPeople()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("SampleDB")))
            {
                //var output = connection.Query<Person>($"SELECT * FROM People where LastName = '{lastName}'").ToList();
                var output = connection.Query<Cars>("dbo.findAllInfo").ToList();

                return output;
            }
        }
        internal void InsertPerson(string make, string model, string colour, double price, double comm, double netvalue )
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("SampleDB")))
            {
                //Person newPerson = new Person { FirstName = firstName, LastName = lastName, EmailAddress = emailAddress, PhoneNumber = phoneNumber };
                List<Cars> cars = new List<Cars>();

                cars.Add(new Cars { Make = make, Model = model, Colour = colour, Price = price, Comm = comm, netValue = netvalue });

                connection.Execute("dbo.Car_Insert @Make, @Model,@Colour, @Price, @Comm, @netValue", cars);
            }
        }
    }
}

