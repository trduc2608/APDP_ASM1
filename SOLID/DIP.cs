public class DIP
{
    public interface IStudentService
    {
        void ManageStudent(Student student);
    }

    public class AddStudent : IStudentService
    {
        public void ManageStudent(Student student)
        {
            // Logic to add student
            Console.WriteLine($"Student {student.Name} added with ID {student.Id}");
        }
    }

    // Define a simple Student class for demonstration purposes
    public class Student
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }

    public class StudentManagement
    {
        private readonly IStudentService _studentService;

        public StudentManagement(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public void ManageStudent(Student student)
        {
            _studentService.ManageStudent(student);
        }
    }

    public interface ICourseService
    {
        void ManageCourse(Course course);
    }

    public class AddCourse : ICourseService
    {
        public void ManageCourse(Course course)
        {
            // Logic to add course
            Console.WriteLine($"Course {course.Title} added with ID {course.Id}");
        }
    }

    // Define a simple Course class for demonstration purposes
    public class Course
    {
        public string Id { get; set; }
        public string Title { get; set; }
    }

    public class CourseManagement
    {
        private readonly ICourseService _courseService;

        public CourseManagement(ICourseService courseService)
        {
            _courseService = courseService;
        }

        public void ManageCourse(Course course)
        {
            _courseService.ManageCourse(course);
        }
    }

    public interface IGradeService
    {
        void ManageGrade(Grade grade);
    }

    public class AddGrade : IGradeService
    {
        public void ManageGrade(Grade grade)
        {
            // Logic to add grade
            Console.WriteLine($"Grade {grade.Score} added for Student ID {grade.StudentId}");
        }
    }

    // Define a simple Grade class for demonstration purposes
    public class Grade
    {
        public string StudentId { get; set; }
        public int Score { get; set; }
    }

    public class GradeManagement
    {
        private readonly IGradeService _gradeService;

        public GradeManagement(IGradeService gradeService)
        {
            _gradeService = gradeService;
        }

        public void ManageGrade(Grade grade)
        {
            _gradeService.ManageGrade(grade);
        }
    }
}