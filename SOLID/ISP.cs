public interface ISP
{
    public interface IAddStudent
    {
        void AddStudent(Student student);
    }

    public interface IUpdateStudent
    {
        void UpdateStudent(Student student);
    }

    public class Student
    {
        public string StudentId { get; set; }
        public string Name { get; set; }
        // Other student-related properties
    }

    public class StudentManagement : IAddStudent, IUpdateStudent
    {
        private List<Student> students = new List<Student>();

        public void AddStudent(Student student)
        {
            if (students.Any(s => s.StudentId == student.StudentId))
            {
                throw new InvalidOperationException("Student with same ID already exists.");
            }
            students.Add(student);
        }

        public void UpdateStudent(Student student)
        {
            var existingStudent = students.FirstOrDefault(s => s.StudentId == student.StudentId);
            if (existingStudent != null)
            {
                existingStudent.Name = student.Name;
                // Other properties can be updated similarly
            }
            else
            {
                throw new InvalidOperationException("Student not found.");
            }
        }
    }

    public interface IAddCourse
    {
        void AddCourse(Course course);
    }

    public interface IUpdateCourse
    {
        void UpdateCourse(Course course);
    }

    public class Course
    {
        public string CourseId { get; set; }
        public string CourseName { get; set; }
        // Other course-related properties
    }

    public class CourseManagement : IAddCourse, IUpdateCourse
    {
        private List<Course> courses = new List<Course>();

        public void AddCourse(Course course)
        {
            if (courses.Any(c => c.CourseId == course.CourseId))
            {
                throw new InvalidOperationException("Course with same ID already exists.");
            }
            courses.Add(course);
        }

        public void UpdateCourse(Course course)
        {
            var existingCourse = courses.FirstOrDefault(c => c.CourseId == course.CourseId);
            if (existingCourse != null)
            {
                existingCourse.CourseName = course.CourseName;
                // Other properties can be updated similarly
            }
            else
            {
                throw new InvalidOperationException("Course not found.");
            }
        }
    }

    public interface IAddGrade
    {
        void AddGrade(Grade grade);
    }

    public interface IUpdateGrade
    {
        void UpdateGrade(Grade grade);
    }

    public class Grade
    {
        public string StudentId { get; set; }
        public string CourseId { get; set; }
        public decimal Score { get; set; }
        // Other grade-related properties
    }

    public class GradeManagement : IAddGrade, IUpdateGrade
    {
        private List<Grade> grades = new List<Grade>();

        public void AddGrade(Grade grade)
        {
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
            if (existingGrade != null)
            {
                existingGrade.Score = grade.Score;
                // Other properties can be updated similarly
            }
            else
            {
                throw new InvalidOperationException("Grade not found.");
            }
        }
    }
}