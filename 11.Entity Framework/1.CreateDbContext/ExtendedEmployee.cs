namespace _1.CreateDbContext
{
    using System.Data.Linq;

    //8.By inheriting the Employee entity class create a class which allows employees to access 
    //their corresponding territories as property of type EntitySet<T>
    public class ExtendedEmployee : Employee
    {
        public EntitySet<Territory> TerritoriesEntities
        {
            get
            {
                EntitySet<Territory> territoriesSet = new EntitySet<Territory>();
                territoriesSet.AddRange(this.Territories);
                return territoriesSet;
            }
        }
    }
}
