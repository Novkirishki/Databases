namespace LogsDB.Importer
{
    using System;
    using LogsDB.Data;
    using Models;

    public static class LogsImporter
    {
        public static void Import(LogsEntities db, int count)
        {
            Random random = new Random();
            var date = new DateTime(2000, 1,1,1,1,1);

            string[] texts = new string[10] 
            {
                "Today",
                "is",
                "going",
                "to",
                "be",
                "a",
                "rally",
                "great",
                "day",
                "!!!"
            };

            for (int i = 0; i < count; i++)
            {
                db.Logs.Add(new Log()
                {
                    Text = texts[i%10],
                    Date = date.AddSeconds(i),
                });

                if (i % 100 == 0)
                {
                    db.SaveChanges();
                    db.Dispose();
                    db = new LogsEntities();
                    db.Configuration.AutoDetectChangesEnabled = false;
                    db.Configuration.ValidateOnSaveEnabled = false;                   
                }

                if (i % 10000 == 0)
                {
                    Console.Write(".");
                }
            }

            db.SaveChanges();
        }
    }
}
