namespace PetStore.Importer
{
    using System;
    using Data;

    public static class CategoriesImporter
    {
        public static void Import(PetStoreEntities db, int count)
        {
            for (int i = 0; i < count; i++)
            {
                db.Categories.Add(new Category()
                {
                    Name = RandomGenerator.Instance.GetRandomString(5, 20)
                });
            }

            db.SaveChanges();
            Console.WriteLine("Categories added!");
        }
    }
}
