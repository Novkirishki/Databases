namespace _7.WriteToExcel
{
    using System.Data.OleDb;

    public class Program
    {
        private static void InsertRow(string name, int score)
        {
            var connectionStringFor2007OrNewer = "Provider = Microsoft.ACE.OLEDB.12.0; Extended Properties = Excel 12.0 XML; Data Source = ../../../scores.xlsx;";
            //var connectionStringForOlder = "Provider = Microsoft.Jet.OLEDB.4.0; Extended Properties = Excel 8.0; Data Source = ../../../scores.xlsx;";

            using (var dbCon = new OleDbConnection(connectionStringFor2007OrNewer))
            {
                dbCon.Open();
                var docName = dbCon.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null).Rows[0]["TABLE_NAME"].ToString();

                var cmd = new OleDbCommand("INSERT INTO [" + docName + "] VALUES (@name, @score)", dbCon);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@score", score);

                cmd.ExecuteNonQuery();
            }
        }

        static void Main()
        {
            InsertRow("Miro", 12);
        }
    }
}
