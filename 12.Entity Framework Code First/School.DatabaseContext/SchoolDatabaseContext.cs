namespace School.DatabaseContext
{
    using Data;
    using System.Data.Entity;

    public class SchoolDatabaseContext : DbContext
    {
        public SchoolDatabaseContext() : base("SchoolDB")
        {
        }

        public virtual IDbSet<Student> Students { get; set; }

        public virtual IDbSet<Course> Courses { get; set; }

        public virtual IDbSet<Homework> Homeworks { get; set; }
    }
}
