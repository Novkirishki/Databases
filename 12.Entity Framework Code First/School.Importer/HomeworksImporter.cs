namespace School.Importer
{
    using System;
    using System.Linq;
    using DatabaseContext;
    using Data;

    public static class HomeworksImporter
    {
        public static void Import(SchoolDatabaseContext db, int count)
        {
            var generator = RandomGenerator.Instance;

            var coursesIDs = db.Courses.Select(c => c.Id).OrderBy(c => Guid.NewGuid()).ToList();

            for (int i = 0; i < count; i++)
            {
                var courseID = coursesIDs[generator.GetRandomNumber(0, coursesIDs.Count - 1)];
                var course = db.Courses
                    .Where(c => c.Id == courseID)
                    .First();

                var studentsIDsFromCourse = course.Students.Select(s => s.Id).ToList();

                var studentID = studentsIDsFromCourse[generator.GetRandomNumber(0, studentsIDsFromCourse.Count - 1)];

                db.Homeworks.Add(new Homework()
                {
                    Content = generator.GetRandomString(100, 300),
                    TimeSent = generator.GetRandomDate(DateTime.Now.AddDays(-100), DateTime.Now),
                    StudentId = studentID,
                    CourseId = courseID
                });
            }

            db.SaveChanges();
            Console.WriteLine("{0} Homeworks imported", count);
        }
    }
}
