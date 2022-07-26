using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
namespace Student_Profiling.Models
{
    class StudentGradeModel:DBConnection
    {
        public bool SaveGradeRating(List<string> GradeRating, List<string> Remarks, List<string> id)
        {
            try
            {
                connect();
                cmd.CommandText = $"UPDATE tbl_enlist_dtl set grade = (CASE id {string.Join(" ",GradeRating)} END), remark = (CASE id {string.Join(" ", Remarks)} END), posted = true  WHERE id IN ({string.Join(", ", id)})";
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message} \n");
                return false;
            } finally
            {
                cmd.Dispose();
                disconnect_db();
            }
        }

        public string GetSubjectDescription(string SubjectCode)
        {
            try
            {
                connect();
                cmd.CommandText = $"SELECT CONCAT(courseCode,'| ', subjCode, ' - ' , subjDesc) AS SubjectDesc FROM tbl_subject WHERE subjCode = '{SubjectCode}'";
                reader = cmd.ExecuteReader();
                return (reader.Read()) ? reader.GetString("SubjectDesc").ToUpper() : null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }finally
            {
                reader.Dispose();
                disconnect_db();
            }
        }
        public DataTable LoadStudentSubject(string SubjectID)
        {
            DataTable dt = new DataTable();
            try
            {
                connect();
                cmd.CommandText = $"SELECT enlist.id, enlist.`studID`, CONCAT(stud.`lname`,', ', stud.`fname`, ' ') AS StudentName,grade, remark  FROM tbl_enlist_dtl AS enlist INNER JOIN tbl_student AS stud ON stud.`studID` = enlist.`studID` INNER JOIN tbl_enlist_sum AS enlist_sum ON enlist_sum.enlistID = enlist.enlistID INNER JOIN  tbl_sy sy ON sy.syID = enlist_sum.syID WHERE sy.status = true AND enlist.`subjID` = '{SubjectID}' ";
                reader = cmd.ExecuteReader();
                dt.Load(reader);
                reader.Dispose();
                disconnect_db();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dt;
        }
        public IList<string> CourseList()
        {
            List<string> _CourseList = new List<string>();
            try
            {
                connect();
                cmd.CommandText = "SELECT courseCode FROM tbl_course where deleted = false";
                reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    _CourseList.Add(reader.GetString("courseCode").ToUpper());
                }
                reader.Dispose();
                disconnect_db();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return _CourseList;
        }

        public DataTable LoadSubjectList(string _where)
        {
            DataTable dt = new DataTable();
            try
            {
                connect();
                cmd.CommandText = $"SELECT  subjCode AS Text, subjID AS Value FROM tbl_subject WHERE {_where}";
                reader = cmd.ExecuteReader();
                dt.Load(reader);
                reader.Close();
                disconnect_db();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dt;
        }
    }
}
