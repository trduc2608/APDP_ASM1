using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM1_1ST_APDP_DucTM_BH01243
{
    public class Teacher : Person
    {
        public string TeacherID { get; set; }
        public Teacher(string firstName, string lastName, string teacherID)
            : base(firstName, lastName)
        {
            TeacherID = teacherID;
        }

        public override string ToString()
        {
            return $"Teacher: {FirstName} {LastName}, ID: {TeacherID}";
        }
    }
}
