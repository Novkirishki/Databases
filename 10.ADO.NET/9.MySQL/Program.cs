namespace _9.MySQL
{
    using MySql.Data.MySqlClient;
    using System;

    public class Program
    {
        private static void SearchBooks(MySqlConnection dbConnection, string keyword)
        {
            Console.WriteLine("Search for :{0}", keyword);

            var command = new MySqlCommand(
              "SELECT * " +
              "FROM Books " +
              "WHERE LOCATE(@keyword, Title)", dbConnection);

            command.Parameters.AddWithValue("@keyword", keyword);

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var title = reader["Title"].ToString();
                    var author = reader["Author"].ToString();
                    var publishDate = DateTime.Parse(reader["PublishData"].ToString());
                    var isbn = reader["ISBN"].ToString();

                    Console.WriteLine("{0} - {1} - {2} - {3}", title, author, publishDate, isbn);
                }
            }
        }

        private static void ListAllBooks(MySqlConnection dbConnection)
        {
            Console.WriteLine("Listing all books:");

            var command = new MySqlCommand(@"SELECT * FROM Books", dbConnection);

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var title = reader["Title"].ToString();
                    var author = reader["Author"].ToString();
                    var publishDate = DateTime.Parse(reader["PublishData"].ToString());
                    var isbn = reader["ISBN"].ToString();

                    Console.WriteLine("{0} - {1} - {2} - {3}", title, author, publishDate, isbn);
                }
            }
        }

        private static void InsertBook(MySqlConnection dbConnection, string title, string author, DateTime publishDate, string isbn)
        {
            Console.WriteLine("Book inserted!");

            var command = new MySqlCommand(@"INSERT INTO Books (Title, Author, PublishData, isbn) VALUES (@title, @author, @date, @isbn) ", dbConnection);
            command.Parameters.AddWithValue("@title", title);
            command.Parameters.AddWithValue("@author", author);
            command.Parameters.AddWithValue("@date", publishDate);
            command.Parameters.AddWithValue("@isbn", isbn);

            command.ExecuteNonQuery();
        }

        public static void Main()
        {
            MySqlConnection dbConnection = new MySqlConnection(
              "Server=localhost; Port=3306; Database=books; Uid = root; Pwd = root; pooling = true"); //set your pass and server
            dbConnection.Open();
            
            ListAllBooks(dbConnection);
            InsertBook(dbConnection, "Inferno", "Dan Brown", DateTime.Now, "99999999999");
            SearchBooks(dbConnection, "dome");
        }
    }
}
