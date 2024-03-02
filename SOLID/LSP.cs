public class LSP
{
    public abstract class Student
    {
        public string StudentId { get; set; }
        public string Name { get; set; }
        public abstract string GetDetails();
    }

    public class UndergraduateStudent : Student
    {
        public string UndergraduateProgram { get; set; }

        public override string GetDetails()
        {
            return $"Undergraduate Student: {Name}, ID: {StudentId}, Program: {UndergraduateProgram}";
        }
    }

    public class GraduateStudent : Student
    {
        public string GraduateProgram { get; set; }

        public override string GetDetails()
        {
            return $"Graduate Student: {Name}, ID: {StudentId}, Program: {GraduateProgram}";
        }
    }

    public abstract class Course
    {
        public string CourseId { get; set; }
        public string CourseName { get; set; }
        public abstract string GetCourseDetails();
    }

    public class UndergraduateCourse : Course
    {
        public int CreditHours { get; set; }

        public override string GetCourseDetails()
        {
            return $"Undergraduate Course: {CourseName}, ID: {CourseId}, Credit Hours: {CreditHours}";
        }
    }

    public class GraduateCourse : Course
    {
        public string ResearchArea { get; set; }

        public override string GetCourseDetails()
        {
            return $"Graduate Course: {CourseName}, ID: {CourseId}, Research Area: {ResearchArea}";
        }
    }

    public abstract class Grade
    {
        public string StudentId { get; set; }
        public string CourseId { get; set; }
        public abstract string GetGrade();
    }

    public class UndergraduateGrade : Grade
    {
        public decimal Score { get; set; }

        public override string GetGrade()
        {
            return $"Undergraduate Grade - Student ID: {StudentId}, Course ID: {CourseId}, Score: {Score}";
        }
    }

    public class GraduateGrade : Grade
    {
        public char LetterGrade { get; set; }

        public override string GetGrade()
        {
            return $"Graduate Grade - Student ID: {StudentId}, Course ID: {CourseId}, Letter Grade: {LetterGrade}";
        }
    }
}