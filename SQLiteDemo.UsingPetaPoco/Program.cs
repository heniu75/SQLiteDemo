﻿using System;
using SharedLib.Data;
using SharedLib.Data.Peta;
using SharedLib.Model;

namespace SQLiteDemo.UsingPetaPoco
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("PETA POCO DEMO WITH SQLLITE");
            ICustomerRepository rep = new PetaPocoCustomerRepository();
            var customer = new Customer
            {
                FirstName = "Sergey",
                LastName = "Maskalik",
                DateOfBirth = DateTime.Now
            };
            rep.SaveCustomer(customer);

            Customer retrievedCustomer = rep.GetCustomer(customer.Id);

            Console.WriteLine("retrieved customer: {0}, {1}, {2}, {3}", retrievedCustomer.Id, retrievedCustomer.FirstName, retrievedCustomer.LastName, retrievedCustomer.DateOfBirth);
            var customers = rep.GetAllCustomers();
            foreach (var cust in customers)
                Console.WriteLine("customer: {0}, {1}, {2}, {3}", cust.Id, cust.FirstName, cust.LastName, cust.DateOfBirth);

        }
    }
}

