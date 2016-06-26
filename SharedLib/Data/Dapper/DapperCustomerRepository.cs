using System.Collections.Generic;
using System.IO;
using System.Linq;
using Dapper;
using SharedLib.Model;

namespace SharedLib.Data.Dapper
{
    public class DapperCustomerRepository : SqLiteBaseRepository, ICustomerRepository
    {
        public Customer GetCustomer(long id)
        {
            if (!File.Exists(DbFile)) return null;

            using (var cnn = SimpleDbConnection())
            {
                cnn.Open();
                var result = cnn.Query<Customer>(@"SELECT * FROM Customer WHERE Id = @id", new { id }).FirstOrDefault();
                return result;
            }
        }

        public void SaveCustomer(Customer customer)
        {
            if (!File.Exists(DbFile))
            {
                CreateDatabase();
            }

            using (var cnn = SimpleDbConnection())
            {
                cnn.Open();
                customer.Id = cnn.Query<long>(
                    @"INSERT INTO Customer 
                    ( FirstName, LastName, DateOfBirth ) VALUES 
                    ( @FirstName, @LastName, @DateOfBirth );
                    select last_insert_rowid()", customer).First();
            }
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            if (!File.Exists(DbFile)) return new List<Customer>();

            using (var cnn = SimpleDbConnection())
            {
                cnn.Open();
                var result = cnn.Query<Customer>("select * from customer");
                return result;
            }
        }
    }
}
