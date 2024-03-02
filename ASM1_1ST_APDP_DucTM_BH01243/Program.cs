using ASM1_1ST_APDP_DucTM_BH01243;

class Program
{
    static void Main(string[] args)
    {
        // Create some departments
        Department computerScience = new Department { DepartmentName = "Computer Science" };
        Department literature = new Department { DepartmentName = "Literature" };

        // Create some teachers
        Teacher mrJones = new Teacher("Tom", "Jones", "TJ123");
        Teacher msSmith = new Teacher("Anna", "Smith", "AS456");

        // Create some courses
        Course programming = new Course("CS101", "Introduction to Programming", mrJones);
        Course englishLiterature = new Course("LT201", "English Literature", msSmith);

        // Add courses to departments
        computerScience.Courses = new List<Course> { programming };
        literature.Courses = new List<Course> { englishLiterature };

        // Create some subjects and add them to courses
        Subject cSharp = new Subject { SubjectCode = "CS1011", SubjectName = "C#", Description = "Basic C# programming" };
        Subject javaSubject = new Subject { SubjectCode = "CS1012", SubjectName = "Java", Description = "Java for beginners" };
        programming.Subjects.Add(cSharp);
        programming.Subjects.Add(javaSubject);

        Subject classicLiterature = new Subject { SubjectCode = "LT2011", SubjectName = "Classics", Description = "Study of classic literature" };
        englishLiterature.Subjects.Add(classicLiterature);

        // Create some students
        Student studentAlice = new Student("Alice", "Johnson", "A1001");
        Student studentBob = new Student("Bob", "Smith", "B2002");

        // Output information about departments, courses, and subjects
        PrintDepartmentCourses(computerScience);
        PrintDepartmentCourses(literature);

        // Output information about Students
        Console.WriteLine(studentAlice.ToString());
        Console.WriteLine(studentBob.ToString());

        // Output information about Teachers
        Console.WriteLine(mrJones.ToString());
        Console.WriteLine(msSmith.ToString());

        Console.ReadKey();
    }

    static void PrintDepartmentCourses(Department department)
    {
        Console.WriteLine($"Department: {department.DepartmentName}");
        foreach (var course in department.Courses)
        {
            Console.WriteLine($" Course: {course.CourseName} ({course.CourseID})");
            Console.WriteLine($"  Instructor: {course.CourseInstructor.FirstName} {course.CourseInstructor.LastName}");
            foreach (var subject in course.Subjects)
            {
                Console.WriteLine($"   Subject: {subject.SubjectName} - {subject.Description}");
            }
        }
    }
}