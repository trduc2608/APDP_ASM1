using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM1_1ST_APDP_DucTM_BH01243
{
    public class Department
    {
        public string DepartmentName { get; set; }
        public List<Course> Courses { get; set; } = new List<Course>(); // Initialize the property inline
    }
}
