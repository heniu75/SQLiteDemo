using System;
using System.Diagnostics;
using SharedLib.Data;
using SharedLib.Data.Simple;
using SharedLib.Model;

namespace SQLiteDemo.UsingSimpleData
{
    class Program
    {
        static void Main(string[] args)
        {
            var listener = new ExampleTraceListener();
            Trace.Listeners.Add(listener);

            Console.WriteLine("SIMPLE DATA DEMO WITH SQLLITE");
            var rep = new SimpleDataCustomerRepository();
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
            var count = rep.GetCountBySample();
            Console.WriteLine(count);

            ShowSql(listener);
        }

        private static void ShowSql(ExampleTraceListener listener)
        {
            Console.WriteLine("--------");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("SQL Sent to database was:");
            Console.WriteLine(listener.Output);
            Console.ResetColor();
        }
    }
}
