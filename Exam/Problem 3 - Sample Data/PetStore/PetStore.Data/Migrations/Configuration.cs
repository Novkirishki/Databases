namespace PetStore.Data.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<PetStoreEntities>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PetStoreEntities context)
        {
        }
    }
}
