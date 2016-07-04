using System;
using System.Data.SQLite;
using Dapper;

namespace SharedLib.Data
{
    public class SQLiteBaseRepository
    {
        public static string DbFile
        {
            get { return Environment.CurrentDirectory + "\\SimpleDb.sqlite"; }
        }

        public static SQLiteConnection SimpleDbConnection()
        {
            var conn = "Data Source=" + DbFile;
            return new SQLiteConnection(conn);
        }

        protected static void CreateDatabase()
        {
            using (var cnn = SimpleDbConnection())
            {
                cnn.Open();
                cnn.Execute(
                    @"create table Customer
                      (
                         ID                                  integer primary key AUTOINCREMENT,
                         FirstName                           varchar(100) not null,
                         LastName                            varchar(100) not null,
                         DateOfBirth                         datetime not null
                      )");
            }
        }
    }
}