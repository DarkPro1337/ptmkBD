using Microsoft.Data.SqlClient;
using RandomPersonLib;
using System;
using System.Threading.Tasks;

namespace ptmkBD
{
    public class Script4
    {
        public static async Task Execute()
        {
            string connectionString = "Server=(LocalDB)\\LocalDB;Database=ptmk;Trusted_Connection=True;";
            
            IRandomPerson randomPerson = new RandomPerson();
            var people = randomPerson.CreatePeople(1000000, Country.USA);

            string format = "yyyy-MM-dd HH:mm:ss"; // Declare the MS SQL format for DateTime

            DateTime start = DateTime.Now;

            foreach (var person in people) {
                string sqlExpression = "INSERT INTO Users (FullName, DateBirth, Gender) VALUES ('" + person.FirstName + " " + person.LastName + "', '" + person.BirthDate.ToString(format) + "', '" + person.Gender.ToString().Substring(0, 1) + "')";
                Console.WriteLine(person.FirstName + " " + person.LastName + " was added to the Users table!");
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();

                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    await command.ExecuteNonQueryAsync();
                }
            }
            DateTime end = DateTime.Now;
            var result = (int)end.Subtract(start).TotalMinutes;
            Console.WriteLine("Elapsed minutes: " + result); // Around 10 minutes on my PC
        }
    }
}
