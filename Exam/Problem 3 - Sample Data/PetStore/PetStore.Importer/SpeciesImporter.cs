namespace PetStore.Importer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Data;

    public static class SpeciesImporter
    {
        public static void Import(PetStoreEntities db, int count)
        {
            var countryIds = db.Countries.OrderBy(c => Guid.NewGuid()).Select(c => c.Id).ToList();

            // using hashset because we must have unique names
            var speciesNames = new HashSet<string>();

            while (speciesNames.Count < count)
            {
                var name = RandomGenerator.Instance.GetRandomString(5, 50);
                speciesNames.Add(name);
            }

            var speciesNamesAsList = speciesNames.ToList();

            // ensure there is atleast one species per country
            for (int i = 0; i < countryIds.Count; i++)
            {
                db.Species.Add(new Species()
                {
                    Name = speciesNamesAsList[i],
                    OriginCountryId = countryIds[i],
                });
            }

            // assign country to other species at random
            for (int i = countryIds.Count; i < speciesNamesAsList.Count; i++)
            {
                db.Species.Add(new Species()
                {
                    Name = speciesNamesAsList[i],
                    OriginCountryId = countryIds[RandomGenerator.Instance.GetRandomNumber(0, countryIds.Count - 1)],
                });
            }

            db.SaveChanges();
            Console.WriteLine("Species added!");
        }
    }
}
