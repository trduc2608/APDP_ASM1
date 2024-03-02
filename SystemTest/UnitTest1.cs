using ASM1_1ST_APDP_DucTM_BH01243;

namespace SystemTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        // Test case for creating a new student
        [Test]
        public void CreateStudent_ValidData_ReturnsStudentInstance()
        {
            var student = new Student("Alice", "Johnson", "A1001");

            Assert.AreEqual("Alice", student.FirstName);
            Assert.AreEqual("Johnson", student.LastName);
            Assert.AreEqual("A1001", student.StudentID);
        }

        // Test case for creating a course and adding a subject
        [Test]
        public void CreateCourse_AddSubject_SubjectListIncreased()
        {
            var teacher = new Teacher("Tom", "Jones", "TJ123");
            var course = new Course("CS101", "Introduction to Programming", teacher);
            var subject = new Subject { SubjectCode = "CS1011", SubjectName = "C#", Description = "Basic C# programming" };
            course.Subjects.Add(subject);

            Assert.Contains(subject, course.Subjects);
        }

        // Test case for setting a course instructor
        [Test]
        public void SetCourseInstructor_ValidTeacher_InstructorSet()
        {
            var teacher = new Teacher("Tom", "Jones", "TJ123");
            var course = new Course("CS101", "Introduction to Programming", null);
            course.CourseInstructor = teacher;

            Assert.AreEqual(teacher, course.CourseInstructor);
        }

        // Test case for outputting a teacher's information
        [Test]
        public void TeacherToString_ValidTeacher_ReturnsCorrectString()
        {
            var teacher = new Teacher("Anna", "Smith", "AS456");
            var stringRepresentation = teacher.ToString();

            StringAssert.AreEqualIgnoringCase("Teacher: Anna Smith, ID: AS456", stringRepresentation);
        }

        // Test case for creating a department with no courses
        [Test]
        public void CreateDepartment_NoCourses_CoursesListIsEmpty()
        {
            var department = new Department { DepartmentName = "Computer Science" };

            Assert.IsEmpty(department.Courses);
        }
    }
}