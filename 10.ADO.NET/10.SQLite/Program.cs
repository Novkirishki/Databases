namespace _10.SQLite
{
    using System.Data.SQLite;
    using System;

    public class Program
    {
        private static void SearchBooks(SQLiteConnection dbConnection, string keyword)
        {
            Console.WriteLine("Search for : {0}", keyword);

            var command = new SQLiteCommand(
              "SELECT * " +
              "FROM Books " +
              "WHERE Title LIKE '%" + keyword + "%'", dbConnection);

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var title = reader["Title"].ToString();
                    var author = reader["Author"].ToString();
                    var publishDate = DateTime.Parse(reader["PublishDate"].ToString());
                    var isbn = reader["ISBN"].ToString();

                    Console.WriteLine("{0} - {1} - {2} - {3}", title, author, publishDate, isbn);
                }
            }
        }

        private static void ListAllBooks(SQLiteConnection dbConnection)
        {
            Console.WriteLine("Listing all books:");

            var command = new SQLiteCommand(@"SELECT * FROM Books", dbConnection);

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var title = reader["Title"].ToString();
                    var author = reader["Author"].ToString();
                    var publishDate = DateTime.Parse(reader["PublishDate"].ToString());
                    var isbn = reader["ISBN"].ToString();

                    Console.WriteLine("{0} - {1} - {2} - {3}", title, author, publishDate, isbn);
                }
            }
        }

        private static void InsertBook(SQLiteConnection dbConnection, string title, string author, DateTime publishDate, string isbn)
        {
            Console.WriteLine("Book inserted!");

            var command = new SQLiteCommand(@"INSERT INTO Books (Title, Author, PublishDate, isbn) VALUES (@title, @author, @date, @isbn) ", dbConnection);
            command.Parameters.AddWithValue("@title", title);
            command.Parameters.AddWithValue("@author", author);
            command.Parameters.AddWithValue("@date", publishDate);
            command.Parameters.AddWithValue("@isbn", isbn);

            command.ExecuteNonQuery();
        }

        public static void Main()
        {
            SQLiteConnection dbConnection = new SQLiteConnection(@"Data Source=../../Books.sqlite;Version=3;"); 
            dbConnection.Open();

            ListAllBooks(dbConnection);
            InsertBook(dbConnection, "aaaa", "John Doe", DateTime.Now, "12345678900");
            SearchBooks(dbConnection, "otter");
        }
    }
}
