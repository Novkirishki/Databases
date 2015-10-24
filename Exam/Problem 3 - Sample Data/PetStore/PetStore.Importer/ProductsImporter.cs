namespace PetStore.Importer
{
    using System;
    using System.Linq;
    using Data;

    public static class ProductsImporter
    {
        public static void Import(PetStoreEntities db, int count)
        {
            var categoriesIds = db.Categories.OrderBy(c => Guid.NewGuid()).Select(c => c.Id).ToList();
            var generator = RandomGenerator.Instance;

            Console.WriteLine("Adding products");

            for (int i = 0; i < count; i++)
            {
                var numberOfSpeciesTheProductIsSuitableFor = generator.GetRandomNumber(2, 10);

                var speciesForCurrentProduct = db.Species.OrderBy(s => Guid.NewGuid()).Take(numberOfSpeciesTheProductIsSuitableFor).ToList();

                db.Products.Add(new Product()
                {
                    Price = generator.GetRandomNumber(10, 1000),
                    Name = generator.GetRandomString(5, 25),
                    CategoryId = categoriesIds[generator.GetRandomNumber(0, categoriesIds.Count - 1)],  
                    Species = speciesForCurrentProduct                  
                });

                if (i % 100 == 0)
                {
                    db.SaveChanges();
                    db.Dispose();
                    db = new PetStoreEntities();
                    db.Configuration.AutoDetectChangesEnabled = false;
                    db.Configuration.ValidateOnSaveEnabled = false;
                    Console.Write(".");
                }
            }

            db.SaveChanges();
        }
    }
}
