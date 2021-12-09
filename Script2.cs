using Microsoft.Data.SqlClient;
using RandomPersonLib;
using System;
using System.Threading.Tasks;

namespace ptmkBD
{
    public class Script2
    {
        public static async Task Execute()
        {
            string connectionString = "Server=(LocalDB)\\LocalDB;Database=ptmk;Trusted_Connection=True;";
            
            IRandomPerson randomPerson = new RandomPerson();
            RandomPersonOptions options = new RandomPersonOptions
            {
                AddCountryCodeToPhoneNumber = true,
                RemoveSpaceFromPhoneNumber = true
            };
            Person person = randomPerson.CreatePerson(Country.USA, options);
            
            string format = "yyyy-MM-dd HH:mm:ss"; // Declare the MS SQL format for DateTime

            string sqlExpression = "INSERT INTO Users (FullName, DateBirth, Gender) VALUES ('" + person.FirstName + " " + person.LastName + "', '" + person.BirthDate.ToString(format) + "', '" + person.Gender.ToString().Substring(0,1) + "')";
            Console.WriteLine(person.FirstName + " " + person.LastName + " was added to the Users table!");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                SqlCommand command = new SqlCommand(sqlExpression, connection);
                await command.ExecuteNonQueryAsync();
            }
        }
    }
}
