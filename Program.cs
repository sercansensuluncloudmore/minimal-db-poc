using System.Collections.Specialized;
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
                            int identifier = reader.GetInt32(0);
                            string name = reader.GetString(1);
                            if (!StringCollection.Equals(name, "Test_Username") && identifier != 1)
                            {
                                throw new Exception("App Failed! There is no test data.");
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
