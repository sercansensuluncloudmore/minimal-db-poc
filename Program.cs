using System;
using System.Data.SqlClient;
using System.Text;

namespace minimal_db_poc
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

                builder.DataSource = "localhost";
                builder.UserID = "sa";
                builder.Password = "dbatools.I0";
                builder.InitialCatalog = "tempdb";

                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    Console.WriteLine("\nQuery data example:");
                    Console.WriteLine("=========================================\n");

                    connection.Open();

                    String sql = "SELECT * FROM Persons";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine("{0} {1}", reader.GetInt32(0), reader.GetString(1));
                            }
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
