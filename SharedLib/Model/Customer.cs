using System;

namespace SharedLib.Model
{
    [PetaPoco.TableName("Customer")]

    [PetaPoco.PrimaryKey("Id")]
    public class Customer
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}