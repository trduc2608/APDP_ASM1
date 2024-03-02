public class OCP
{
    // Assuming these are the data storage for the purposes of this example
    private static List<Student> students = new List<Student>();
    private static List<Course> courses = new List<Course>();
    private static List<Grade> grades = new List<Grade>();

    public class Student
    {
        public string StudentId { get; set; }
        public string Name { get; set; }
        // Other student-related properties
    }

    public class Course
    {
        public string CourseId { get; set; }
        public string CourseName { get; set; }
        // Other course-related properties
    }

    public class Grade
    {
        public string StudentId { get; set; }
        public string CourseId { get; set; }
        public decimal Score { get; set; }
        // Other grade-related properties
    }

    public abstract class StudentManagement
    {
        public abstract void ManageStudent(Student student);
    }

    public class AddStudent : StudentManagement
    {
        public override void ManageStudent(Student student)
        {
            if (students.Any(s => s.StudentId == student.StudentId))
            {
                throw new InvalidOperationException("Student with same ID already exists.");
            }
            students.Add(student);
        }
    }

    public class UpdateStudent : StudentManagement
    {
        public override void ManageStudent(Student student)
        {
            var existingStudent = students.FirstOrDefault(s => s.StudentId == student.StudentId);
            if (existingStudent == null)
            {
                throw new InvalidOperationException("Student not found.");
            }
            existingStudent.Name = student.Name;
            // Other properties can be updated similarly
        }
    }

    public abstract class CourseManagement
    {
        public abstract void ManageCourse(Course course);
    }

    public class AddCourse : CourseManagement
    {
        public override void ManageCourse(Course course)
        {
            if (courses.Any(c => c.CourseId == course.CourseId))
            {
                throw new InvalidOperationException("Course with same ID already exists.");
            }
            courses.Add(course);
        }
    }

    public class UpdateCourse : CourseManagement
    {
        public override void ManageCourse(Course course)
        {
            var existingCourse = courses.FirstOrDefault(c => c.CourseId == course.CourseId);
            if (existingCourse == null)
            {
                throw new InvalidOperationException("Course not found.");
            }
            existingCourse.CourseName = course.CourseName;
            // Other properties can be updated similarly
        }
    }

    public abstract class GradeManagement
    {
        public abstract void ManageGrade(Grade grade);
    }

    public class AddGrade : GradeManagement
    {
        public override void ManageGrade(Grade grade)
        {
            var existingGrade = grades.FirstOrDefault(g => g.StudentId == grade.StudentId && g.CourseId == grade.CourseId);
            if (existingGrade != null)
            {
                throw new InvalidOperationException("Grade for this course and student already exists.");
            }
            grades.Add(grade);
        }
    }

    public class UpdateGrade : GradeManagement
    {
        public override void ManageGrade(Grade grade)
        {
            var existingGrade = grades.FirstOrDefault(g => g.StudentId == grade.StudentId && g.CourseId == grade.CourseId);
            if (existingGrade == null)
            {
                throw new InvalidOperationException("Grade not found.");
            }
            existingGrade.Score = grade.Score;
            // Other properties can be updated similarly
        }
    }

    public class DeleteStudent : StudentManagement
    {
        public override void ManageStudent(Student student)
        {
            var studentToDelete = students.FirstOrDefault(s => s.StudentId == student.StudentId);
            if (studentToDelete != null)
            {
                students.Remove(studentToDelete);
            }
            else
            {
                throw new InvalidOperationException("Student not found.");
            }
        }
    }

    public class DeleteCourse : CourseManagement
    {
        public override void ManageCourse(Course course)
        {
            var courseToDelete = courses.FirstOrDefault(c => c.CourseId == course.CourseId);
            if (courseToDelete != null)
            {
                courses.Remove(courseToDelete);
            }
            else
            {
                throw new InvalidOperationException("Course not found.");
            }
        }
    }

    public class DeleteGrade : GradeManagement
    {
        public override void ManageGrade(Grade grade)
        {
            var gradeToDelete = grades.FirstOrDefault(g => g.StudentId == grade.StudentId && g.CourseId == grade.CourseId);
            if (gradeToDelete != null)
            {
                grades.Remove(gradeToDelete);
            }
            else
            {
                throw new InvalidOperationException("Grade not found.");
            }
        }
    }
}