namespace _2.CategoriesNameAndDescription
{
    using System;
    using System.Data.SqlClient;

    public class Program
    {
        public static void Main()
        {
            SqlConnection dbCon = new SqlConnection(
                "Server=.; " +
                "Database=Northwind; " +
                "Integrated Security=true");
            dbCon.Open();

            using (dbCon)
            {
                SqlCommand command = new SqlCommand(
                  "SELECT * FROM Categories", dbCon);

                SqlDataReader reader = command.ExecuteReader();

                using (reader)
                {
                    while (reader.Read())
                    {
                        string name = (string)reader["CategoryName"];
                        string description = (string)reader["Description"];
                        Console.WriteLine("{0} - {1}", name, description);
                    }
                }
            }
        }
    }
}

