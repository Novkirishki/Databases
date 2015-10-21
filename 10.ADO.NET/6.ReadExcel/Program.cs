namespace _6.ReadExcel
{
    using System;
    using System.Data;
    using System.Data.OleDb;

    public class Program
    {
        static void Main()
        {
            var connectionStringFor2007OrNewer = "Provider = Microsoft.ACE.OLEDB.12.0; Extended Properties = Excel 12.0 XML; Data Source = ../../../scores.xlsx;";
            //var connectionStringForOlder = "Provider = Microsoft.Jet.OLEDB.4.0; Extended Properties = Excel 8.0; Data Source = ../../../scores.xlsx;";

            using (var dbCon = new OleDbConnection(connectionStringFor2007OrNewer))
            {
                dbCon.Open();
                var docName = dbCon.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null).Rows[0]["TABLE_NAME"].ToString();
                var cmd = new OleDbCommand("SELECT * FROM [" + docName + "]", dbCon);

                using (var oleDbAdapter = new OleDbDataAdapter(cmd))
                {
                    var dataSet = new DataSet();
                    oleDbAdapter.Fill(dataSet);

                    using (var reader = dataSet.CreateDataReader())
                    {
                        while (reader.Read())
                        {
                            var name = reader["Name"];
                            var score = reader["Score"];
                            Console.WriteLine("{0}: {1}", name, score);
                        }
                    }
                }
            }
        }
    }
}
