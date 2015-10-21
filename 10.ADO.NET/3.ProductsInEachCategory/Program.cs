namespace _3.ProductsInEachCategory
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
                  "SELECT c.CategoryName, p.ProductName " +
                  "FROM Categories c " +
                  "JOIN Products p ON c.CategoryID = p.CategoryID " +
                  "ORDER BY c.CategoryName", dbCon);

                SqlDataReader reader = command.ExecuteReader();

                using (reader)
                {
                    string previousCategory = string.Empty;

                    while (reader.Read())
                    {                       
                        string category = (string)reader["CategoryName"];
                        string product = (string)reader["ProductName"];

                        if (category == previousCategory)
                        {
                            Console.Write(", {0}", product);
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.Write("{0} - {1}", category, product);
                            previousCategory = category;
                        }                      
                    }
                }
            }
        }
    }
}

