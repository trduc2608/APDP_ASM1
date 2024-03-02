using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM1_1ST_APDP_DucTM_BH01243
{
    public class Student : Person
    {
        public string StudentID { get; set; }
        // Constructor chaining to Person class
        public Student(string firstName, string lastName, string studentID)
            : base(firstName, lastName)
        {
            StudentID = studentID;
        }

        // Polymorphism through method overriding "virtual" in base, "override" in derived
        public override string ToString()
        {
            return $"Student: {FirstName} {LastName}, ID: {StudentID}";
        }
    }
}
