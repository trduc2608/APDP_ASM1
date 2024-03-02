public class SRP
{
    // Assume these are data storage for the purposes of this example
    private static List<Student> students = new List<Student>();
    private static List<Course> courses = new List<Course>();
    private static List<Grade> grades = new List<Grade>();

    public class Student
    {
        public string StudentId { get; set; }
        public string Name { get; set; }
        // Other student-related properties
    }

    public class StudentService
    {
        public void AddStudent(Student student)
        {
            // Assumption: No duplicate StudentId is allowed
            if (students.Any(s => s.StudentId == student.StudentId))
            {
                throw new InvalidOperationException("Student with same ID already exists.");
            }
            students.Add(student);
        }

        public void UpdateStudent(Student student)
        {
            var existingStudent = students.FirstOrDefault(s => s.StudentId == student.StudentId);
            if (existingStudent == null)
            {
                throw new InvalidOperationException("Student not found.");
            }
            existingStudent.Name = student.Name;
        }

        public void DeleteStudent(string studentId)
        {
            var student = students.FirstOrDefault(s => s.StudentId == studentId);
            if (student != null)
            {
                students.Remove(student);
            }
        }
    }

    public class Course
    {
        public string CourseId { get; set; }
        public string CourseName { get; set; }
    }

    public class CourseService
    {
        public void AddCourse(Course course)
        {
            // Assumption: No duplicate CourseId is allowed
            if (courses.Any(c => c.CourseId == course.CourseId))
            {
                throw new InvalidOperationException("Course with same ID already exists.");
            }
            courses.Add(course);
        }

        public void UpdateCourse(Course course)
        {
            var existingCourse = courses.FirstOrDefault(c => c.CourseId == course.CourseId);
            if (existingCourse == null)
            {
                throw new InvalidOperationException("Course not found.");
            }
            existingCourse.CourseName = course.CourseName;
        }

        public void DeleteCourse(string courseId)
        {
            var course = courses.FirstOrDefault(c => c.CourseId == courseId);
            if (course != null)
            {
                courses.Remove(course);
            }
        }
    }

    public class Grade
    {
        public string StudentId { get; set; }
        public string CourseId { get; set; }
        public int Score { get; set; }
    }

    public class GradeService
    {
        public void AddGrade(Grade grade)
        {
            // Logic to add grade, assuming a student can only have one grade per course
            var existingGrade = grades.FirstOrDefault(g => g.StudentId == grade.StudentId && g.CourseId == grade.CourseId);
            if (existingGrade != null)
            {
                throw new InvalidOperationException("Grade for this course and student already exists.");
            }
            grades.Add(grade);
        }

        public void UpdateGrade(Grade grade)
        {
            var existingGrade = grades.FirstOrDefault(g => g.StudentId == grade.StudentId && g.CourseId == grade.CourseId);
            if (existingGrade == null)
            {
                throw new InvalidOperationException("Grade not found.");
            }
            existingGrade.Score = grade.Score;
        }

        public void DeleteGrade(string studentId, string courseId)
        {
            var grade = grades.FirstOrDefault(g => g.StudentId == studentId && g.CourseId == courseId);
            if (grade != null)
            {
                grades.Remove(grade);
            }
            else
            {
                throw new InvalidOperationException("Grade not found.");
            }
        }
    }
}

// Main program entry point for interacting with the SRP-compliant services
class Program
{
    static void Main()
    {
        var studentService = new SRP.StudentService();
        var courseService = new SRP.CourseService();
        var gradeService = new SRP.GradeService();

        // Create a new student and add them to the system
        var student = new SRP.Student { StudentId = "S3001", Name = "Jane Doe" };
        studentService.AddStudent(student);

        // Create a new course and add it to the system
        var course = new SRP.Course { CourseId = "CS102", CourseName = "Data Structures" };
        courseService.AddCourse(course);

        // Assign a grade to the student for the course
        var grade = new SRP.Grade { StudentId = "S3001", CourseId = "CS102", Score = 95 };
        gradeService.AddGrade(grade);

        // Update student information
        student.Name = "Jane D. Doe";
        studentService.UpdateStudent(student);

        // Update course information
        course.CourseName = "Advanced Data Structures";
        courseService.UpdateCourse(course);

        // Update grade information
        grade.Score = 98;
        gradeService.UpdateGrade(grade);

        Console.WriteLine("Operations completed successfully.");
    }
}