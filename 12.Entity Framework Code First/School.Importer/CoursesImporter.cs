namespace School.Importer
{
    using System;
    using System.Linq;
    using DatabaseContext;
    using Data;

    public static class CoursesImporter
    {
        public static void Import(SchoolDatabaseContext db, int count)
        {
            var generator = RandomGenerator.Instance;

            var studentsIDs = db.Students.Select(s => s.Id).OrderBy(s => Guid.NewGuid()).ToList();

            for (int i = 0; i < count; i++)
            {
                var course = new Course()
                {
                    Name = generator.GetRandomString(5, 20),
                    Description = generator.GetRandomString(50, 200),
                    Materials = generator.GetRandomString(10, 100),
                };

                var studentsInCourse = generator.GetRandomNumber(20, 30);

                for (int j = 0; j < studentsInCourse; j++)
                {
                    var studentID = studentsIDs[generator.GetRandomNumber(0, studentsIDs.Count - 1)];
                    course.Students.Add(db.Students.Where(s => s.Id == studentID).First());
                }

                db.Courses.Add(course);
            }

            db.SaveChanges();
            Console.WriteLine("{0} Courses imported", count);
        }
    }
}

