namespace LogsDB.ConsoleClient
{
    using LogsDB.Data;
    using Importer;

    public class Program
    {
        public static void Main()
        {
            using (var db = new LogsEntities())
            {
                LogsImporter.Import(db, 10000000);
            }
        }
    }
}
