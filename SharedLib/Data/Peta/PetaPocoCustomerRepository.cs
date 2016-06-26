using System.Collections.Generic;
using System.IO;
using System.Linq;
using SharedLib.Model;

namespace SharedLib.Data.Peta
{
    public class PetaPocoCustomerRepository : SqLiteBaseRepository, ICustomerRepository
    {
        public Customer GetCustomer(long id)
        {
            if (!File.Exists(DbFile)) return null;

            using (var cnn = SimpleDbConnection())
            {
                using (var db = new PetaPoco.Database(cnn))
                {
                    cnn.Open();
                    var result = db.SingleOrDefault<Customer>("select * from customer where id=@0", id);
                    return result;
                }
            }
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            if (!File.Exists(DbFile)) return new List<Customer>();

            using (var cnn = SimpleDbConnection())
            {
                using (var db = new PetaPoco.Database(cnn))
                {
                    cnn.Open();
                    var result = db.Query<Customer>("select * from customer");
                    return result.ToList();
                }
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
                using (var db = new PetaPoco.Database(cnn))
                {
                    cnn.Open();
                    db.Insert(customer);
                }
            }
        }
    }
}
