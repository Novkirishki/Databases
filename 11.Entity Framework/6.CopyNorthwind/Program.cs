namespace _6.CopyNorthwind
{
    public class Program
    {
        public static void Main()
        {
            //6.Create a database called NorthwindTwin with the same structure as Northwind using the features from DbContext.
            var db = new NorthwindEntities();
            db.Database.CreateIfNotExists();
        }
    }
}
