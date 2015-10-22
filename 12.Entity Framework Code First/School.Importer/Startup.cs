namespace School.Importer
{
    using System;
    using System.Linq;
    using DatabaseContext;

    public class Startup
    {
        public static void Main()
        {
            //Be patient it is not fast, it will take 5-10 seconds :)
            using (var db = new SchoolDatabaseContext())
            {
                StudentsImporter.Import(db, 300);
                CoursesImporter.Import(db, 7);
                HomeworksImporter.Import(db, 1200);
            }

            using (var db = new SchoolDatabaseContext())
            {
                var course = db.Courses.Where(c => c.Id == 2).First();
                var homeworks = course.Homeworks.Where(h => h.TimeSent > DateTime.Now.AddDays(-7));
                Console.WriteLine("Homeworks from course 2 that have been sent in the last week:");

                foreach (var homework in homeworks)
                {
                    Console.WriteLine("Content: {0}", homework.Content);
                    Console.WriteLine("Send by: {0}", homework.Student.Name);
                }

            }
        }
    }
}
