namespace PetStore.ConsoleClient
{
    using Data;
    using Importer;

    public class Stratup
    {
        public static void Main()
        {
            using (var db = new PetStoreEntities())
            {
                CountriesImporter.Import(db, 20);
                SpeciesImporter.Import(db, 100);
                PetsImporter.Import(db, 5000);               
            }

            using (var db = new PetStoreEntities())
            {
                CategoriesImporter.Import(db, 50);
                ProductsImporter.Import(db, 20000);
            }
        }
    }
}
