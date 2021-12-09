using Microsoft.Data.SqlClient;
using RandomPersonLib;
using System;
using System.Threading.Tasks;

namespace ptmkBD
{
    class Script5
    {
        public static async Task Execute()
        {
            string connectionString = "Server=(LocalDB)\\LocalDB;Database=ptmk;Trusted_Connection=True;";

            string sqlExpression = "SELECT FullName, Gender FROM Users WHERE (FullName LIKE 'F%') AND (Gender = 'M')";

            DateTime start = DateTime.Now;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = await command.ExecuteReaderAsync();

                if (reader.HasRows)
                {
                    string columnName1 = reader.GetName(0);
                    string columnName2 = reader.GetName(1);

                    Console.WriteLine($"{columnName1}\t{columnName2}");

                    while (await reader.ReadAsync())
                    {
                        object fullName = reader.GetValue(0);
                        object gender = reader.GetValue(1);

                        Console.WriteLine($"{fullName} \t{gender}");
                    }
                }

                await reader.CloseAsync();
            }

            DateTime end = DateTime.Now;
            var result = (int)end.Subtract(start).TotalSeconds;
            Console.WriteLine("Elapsed seconds: " + result); // Around 4 seconds on my PC
        }
    }
}
