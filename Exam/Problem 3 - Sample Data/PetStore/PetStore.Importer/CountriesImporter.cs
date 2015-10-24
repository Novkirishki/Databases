namespace PetStore.Importer
{
    using System;
    using System.Collections.Generic;
    using Data;

    public static class CountriesImporter
    {
        public static void Import(PetStoreEntities db, int count)
        {
            // using hashset because we must have unique names
            var countryNames = new HashSet<string>();

            while (countryNames.Count < count)
            {
                var name = RandomGenerator.Instance.GetRandomString(5, 50);
                countryNames.Add(name);
            }

            foreach (var countryName in countryNames)
            {
                db.Countries.Add(new Country() { Name = countryName });
            }

            db.SaveChanges();
            Console.WriteLine("Countries added!");
        }
    }
}
