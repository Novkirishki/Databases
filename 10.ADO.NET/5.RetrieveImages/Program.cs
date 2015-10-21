namespace _5.RetrieveImages
{
    using System.Data.SqlClient;
    using System.IO;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System;

    public class Program
    {
        private static void SaveImage(int categoryID, byte[] data)
        {
            using (var stream = new MemoryStream(data, 78, data.Length - 78))
            {
                Image image = Image.FromStream(stream);
                var filePath = string.Format("{0}.jpg", categoryID);
                image.Save(filePath, ImageFormat.Jpeg);
            }
        }

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
                  "SELECT * " +
                  "FROM Categories", dbCon);

                SqlDataReader reader = command.ExecuteReader();

                using (reader)
                {
                    while (reader.Read())
                    {
                        byte[] image = (byte[])reader["Picture"];
                        int category = (int)reader["CategoryID"];

                        SaveImage(category, image);
                    }
                }
            }

            Console.WriteLine("Images saved in bin\\Debug");
        }
    }
}