﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DbUp;

namespace SQLiteDemo.DbUpConsole
{
    class Program
    {
        static int Main(string[] args)
        {
            var connectionString = args.FirstOrDefault()
                         ?? "Data Source = " + Environment.CurrentDirectory + "\\SimpleDb.sqlite";

            var upgrader =
                DeployChanges.To
                    .SQLiteDatabase(connectionString)
                    .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
                    .LogToConsole()
                    .Build();

            var result = upgrader.PerformUpgrade();

            if (!result.Successful)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(result.Error);
                Console.ResetColor();
#if DEBUG
                Console.ReadLine();
#endif
                return -1;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Success!");
            Console.ResetColor();
            return 0;
        }
    }
}
