namespace ASM1_1ST_APDP_DucTM_BH01243
{
    public class Course
    {
        public string CourseID { get; set; }
        public string CourseName { get; set; }
        public List<Subject> Subjects { get; set; }
        // Encapsulated private field with a public getter method
        private Teacher courseInstructor;
        public Teacher CourseInstructor
        {
            get { return courseInstructor; }
            set { courseInstructor = value; }
        }

        public Course(string courseID, string courseName, Teacher instructor)
        {
            CourseID = courseID;
            CourseName = courseName;
            courseInstructor = instructor;
            Subjects = new List<Subject>();
        }
    }

}
