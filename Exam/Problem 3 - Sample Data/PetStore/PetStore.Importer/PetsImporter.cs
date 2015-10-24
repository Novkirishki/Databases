namespace PetStore.Importer
{
    using System;
    using System.Linq;
    using Data;

    public static class PetsImporter
    {
        public static void Import(PetStoreEntities db, int count)
        {
            var speciesIds = db.Species.OrderBy(s => Guid.NewGuid()).Select(s => s.Id).ToList();
            var generator = RandomGenerator.Instance;
            var colorIds = db.Colors.OrderBy(c => Guid.NewGuid()).Select(c => c.Id).ToList();

            Console.WriteLine("Adding pets");

            for (int i = 0; i < count; i++)
            {
                db.Pets.Add(new Pet()
                {
                    Breed = generator.GetRandomString(5, 30),
                    Price = generator.GetRandomNumber(5, 2500),
                    ColorId = colorIds[generator.GetRandomNumber(0, colorIds.Count - 1)],
                    DateOfBirth = generator.GetRandomDate(new DateTime(2010, 1, 1), DateTime.Now.AddDays(-60)),
                    SpeciesId = speciesIds[generator.GetRandomNumber(0, speciesIds.Count - 1)]
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
