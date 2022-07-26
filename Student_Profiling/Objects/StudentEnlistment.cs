using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Profiling.Objects
{
    class StudentEnlistment
    {
        public byte[] img { get; set; }
        public string EnlistID { get; set; }
        public string YearLevel { get; set; }
        public string StudentID { get; set; }
        public string StudentName { get; set; }
        public string CourseCode { get; set; }
        public string Course { get; set; }
        public string Sem { get; set; }
        public string Level { get; set; }
        public string SchoolYear { get; set; }
        public string TotalCredits { get; set; }
        public string syID { get; set; }
        public DataTable SubjectList = new DataTable();

    }
}
