using Microsoft.Data.SqlClient;
using RandomPersonLib;
using System;
using System.Threading.Tasks;

namespace ptmkBD
{
    public class Script3
    {
        public static async Task Execute()
        {
            string connectionString = "Server=(LocalDB)\\LocalDB;Database=ptmk;Trusted_Connection=True;";

            string sqlExpression = "SELECT DISTINCT FullName, DateBirth, Gender, DATEDIFF(YY, DateBirth, GETDATE()) AS Age FROM Users";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = await command.ExecuteReaderAsync();

                if (reader.HasRows)
                {
                    string columnName1 = reader.GetName(0);
                    string columnName2 = reader.GetName(1);
                    string columnName3 = reader.GetName(2);
                    string columnName4 = reader.GetName(3);

                    Console.WriteLine($"{columnName1}\t{columnName2}\t{columnName4}\t{columnName3}");

                    while (await reader.ReadAsync())
                    {
                        object fullName = reader.GetValue(0);
                        object dateBirth = reader.GetValue(1);
                        object gender = reader.GetValue(2);
                        object age = reader.GetValue(3);

                        Console.WriteLine($"{fullName} \t{dateBirth} \t{age} \t{gender}");
                    }
                }

                await reader.CloseAsync();
            }
        }
    }
}
