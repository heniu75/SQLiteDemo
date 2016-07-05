using System;
using System.Collections.Generic;
using System.IO;
using SharedLib.Model;
using Simple.Data;

namespace SharedLib.Data.Simple
{
    public class SimpleDataCustomerRepository : SQLiteBaseRepository, ICustomerRepository
    {
        public Customer GetCustomer(long id)
        {
            if (!File.Exists(DbFile)) return null;

            var db = Database.Opener.OpenFile(GetConnectionString());
            var customer = db.Customer.FindById(id);
            return customer;
        }

        private string GetConnectionString()
        {
            var dbFileName = Path.Combine(Environment.CurrentDirectory, "SimpleDb.sqlite");
           // var connString = string.Format("Data Source={0}", dbFileName);
            return dbFileName;
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            if (!File.Exists(DbFile)) return new List<Customer>();

            var db = Database.Opener.OpenFile(GetConnectionString());
            List<Customer> customers = db.Customer.All();
            return customers;
        }

        public int GetCountBySample()
        {
            var db = Database.Opener.OpenFile(GetConnectionString());
            var count = db.Customer.GetCountByFirstName("Sergey1");
            return count;
        }

        public void SaveCustomer(Customer customer)
        {
            if (!File.Exists(DbFile))
                CreateDatabase();

            var db = Database.Opener.OpenFile(GetConnectionString());
            var result = db.Customer.Insert(customer);
            customer.Id = result.Id;
        }
    }
}
