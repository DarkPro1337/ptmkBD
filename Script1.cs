using Microsoft.Data.SqlClient;
using System;
using System.Threading.Tasks;

namespace ptmkBD
{
    public class Script1
    {
        public static async Task Execute()
        {
            string connectionString = "Server=(LocalDB)\\LocalDB;Database=master;Trusted_Connection=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                Console.WriteLine("Connection open.");

                SqlCommand commandCreateDB = new SqlCommand();
                commandCreateDB.CommandText = "CREATE DATABASE ptmk";
                commandCreateDB.Connection = connection;
                await commandCreateDB.ExecuteNonQueryAsync();
                Console.WriteLine("Database Created!");
            }
            Console.WriteLine("Connection closed...");
            Console.WriteLine("Updating connection string...");

            connectionString = "Server=(LocalDB)\\LocalDB;Database=ptmk;Trusted_Connection=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                Console.WriteLine("Connection open.");

                SqlCommand commandCreateTbl = new SqlCommand();
                commandCreateTbl.CommandText = "CREATE TABLE Users (Id INT PRIMARY KEY IDENTITY, FullName NVARCHAR(128) NOT NULL, DateBirth DATETIME NOT NULL, Gender NVARCHAR(1) NOT NULL)";
                commandCreateTbl.Connection = connection;
                await commandCreateTbl.ExecuteNonQueryAsync();
                Console.WriteLine("Table Users created!");
            }
            Console.WriteLine("Connection closed...");
        }
    }
}
