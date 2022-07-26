using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Student_Profiling.Objects;
using System.Data;

namespace Student_Profiling.Models
{
    class EnlistmentModel:DBConnection
    {
        public StudentEnlistment GetStudentEnlistedInfo(string StudID)
        {
            var studEnlist = new StudentEnlistment();
            try
            {
                connect();
                transact = con.BeginTransaction();
                cmd.Transaction = transact;
                cmd.CommandText = "SELECT tbl_enlist_sum.*,tbl_course.courseDesc, CONCAT(tbl_student.lname,', ', tbl_student.fname, ' ', tbl_student.mi) AS StudentName, tbl_sy.`description` AS sy,tbl_image.Image as img FROM tbl_enlist_sum  INNER JOIN tbl_student ON tbl_student.studID = tbl_enlist_sum.studID INNER JOIN tbl_course ON tbl_course.courseCode = tbl_enlist_sum.courseCode  INNER JOIN tbl_sy ON tbl_sy.`syID` = tbl_enlist_sum.`syID` INNER JOIN tbl_image ON tbl_image.studID = tbl_enlist_sum.studID  WHERE tbl_sy.`status` = TRUE AND tbl_enlist_sum.`studID` = @StudentID";
                cmd.Parameters.AddWithValue("@StudentID", StudID);
                using(reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        studEnlist.img = (Byte[])reader["img"];
                        studEnlist.EnlistID = reader.GetString("enlistID"); 
                        studEnlist.StudentID = reader.GetString("studID");
                        studEnlist.StudentName = reader.GetString("StudentName");
                        studEnlist.CourseCode = reader.GetString("courseCode");
                        studEnlist.Course = reader.GetString("courseDesc");
                        studEnlist.Sem = reader.GetString("sem");
                        studEnlist.Level = reader.GetString("level");
                    }
                }
                cmd.CommandText = "SELECT subj.*,dtl.posted FROM tbl_enlist_dtl AS dtl INNER JOIN tbl_subject subj ON subj.`subjID` = dtl.`subjID` INNER JOIN tbl_enlist_sum AS summ ON summ.`enlistID` = dtl.`enlistID` INNER JOIN tbl_sy AS sy ON sy.`syID` = summ.`syID` WHERE sy.status = TRUE AND summ.`studID` = @StudID";
                cmd.Parameters.AddWithValue("@StudID", StudID);
                using (reader = cmd.ExecuteReader())
                {
                    studEnlist.SubjectList.Load(reader);
                }

               transact.Commit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "WMSU-ESU PAGADIAN");
            }
            finally
            {
                cmd.Parameters.Clear();
                cmd.Dispose();
                reader.Dispose();
            }
            return studEnlist;
        }

        public StudentEnlistment GetNewStudentInfoForEnlistment(string StudID)
        {
            var studEnlist = new StudentEnlistment();
            try
            {
                connect();
                cmd.CommandText = "SELECT tbl_student.`studID`, CONCAT(tbl_student.`lname`,', ', tbl_student.`fname`,' ', tbl_student.`mi`) AS StudentName, tbl_course.courseCode, tbl_course.courseDesc, tbl_image.image FROM tbl_student   INNER JOIN tbl_course ON tbl_course.courseCode = tbl_student.courseCode INNER JOIN tbl_image ON tbl_image.studID = tbl_student.studID WHERE tbl_student.`studID` = @StudentID";
                cmd.Parameters.AddWithValue("@StudentID", StudID);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    studEnlist.StudentID = reader.GetString("studID");
                    studEnlist.Course = reader.GetString("courseDesc");
                    studEnlist.CourseCode = reader.GetString("courseCode");
                    studEnlist.StudentName = reader.GetString("StudentName");
                    studEnlist.img = (byte[])reader["image"];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cmd.Parameters.Clear();
                cmd.Dispose();
                reader.Dispose();
                disconnect_db();
            }
            return studEnlist;
        }

        public bool UpdateEnlistStudent(StudentEnlistment stud)
        {
            try
            {
                connect();
                transact = con.BeginTransaction();
                cmd.Transaction = transact;
                cmd.CommandText = "UPDATE tbl_enlist_sum SET studID =  @StudentID, courseCode = @CourseCode, syID = @SchoolYear, total_credits = @TotalCredits, sem = @Sem, level = @YearLevel WHERE enlistID = @EnlistID";
                cmd.Parameters.AddWithValue("@StudentID", stud.StudentID);
                cmd.Parameters.AddWithValue("@CourseCode", stud.CourseCode);
                cmd.Parameters.AddWithValue("@TotalCredits", stud.TotalCredits);
                cmd.Parameters.AddWithValue("@Sem", stud.Sem);
                cmd.Parameters.AddWithValue("@YearLevel", stud.YearLevel);
                cmd.Parameters.AddWithValue("@SchoolYear", stud.syID);
                cmd.Parameters.AddWithValue("@EnlistID", stud.EnlistID);
                cmd.ExecuteNonQuery();

                cmd.CommandText = $"DELETE FROM tbl_enlist_dtl WHERE enlistID = {stud.EnlistID}";
                cmd.ExecuteNonQuery();

                List<string> SubjList = new List<string>();
                foreach (DataRow row in stud.SubjectList.Rows)
                {
                    SubjList.Add(string.Format("('{0}','{1}','{2}')", row["SubjectID"].ToString(), stud.EnlistID, row["StudentID"].ToString()));
                }

                StringBuilder CommandString = new StringBuilder("INSERT INTO tbl_enlist_dtl (subjID, enlistID, studID) VALUES");
                CommandString.Append(string.Join(",", SubjList));
                CommandString.Append(";");
                cmd.CommandText = CommandString.ToString();
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

                transact.Commit();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
                return false;
            }
            finally
            {
                cmd.Parameters.Clear();
                cmd.Dispose();
                disconnect_db();
            }
        }
        public bool EnlistNewStudent(StudentEnlistment stud)
        {
            try
            {
                connect();
                transact = con.BeginTransaction();
                cmd.Transaction = transact;
                cmd.CommandText = "INSERT tbl_enlist_sum (studID, courseCode,syID, total_credits, sem, level) VALUES (@StudentID, @CourseCode,@SchoolYear, @TotalCredits, @Sem, @YearLevel)";
                cmd.Parameters.AddWithValue("@StudentID", stud.StudentID);
                cmd.Parameters.AddWithValue("@CourseCode", stud.CourseCode);
                cmd.Parameters.AddWithValue("@TotalCredits", stud.TotalCredits);
                cmd.Parameters.AddWithValue("@Sem", stud.Sem);
                cmd.Parameters.AddWithValue("@YearLevel", stud.YearLevel);
                cmd.Parameters.AddWithValue("@SchoolYear", stud.syID);
                cmd.ExecuteNonQuery();
                
                //Getting Last Insert ID in Enlistment;
                string LastInsertID = cmd.LastInsertedId.ToString();
                List<string> SubjList = new List<string>();
                foreach (DataRow row in stud.SubjectList.Rows)
                {
                    SubjList.Add(string.Format("('{0}','{1}','{2}')",row["SubjectID"].ToString(),LastInsertID,row["StudentID"].ToString()));
                }

                StringBuilder CommandString = new StringBuilder("INSERT INTO tbl_enlist_dtl (subjID, enlistID, studID) VALUES");
                CommandString.Append(string.Join(",", SubjList));
                CommandString.Append(";");
                cmd.CommandText = CommandString.ToString();
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

                transact.Commit();
                return true;
            }
            catch (Exception ex)
            {
               MessageBox.Show($"{ex.Message} \n {cmd.CommandText}");
                return false;
            } finally
            {
                cmd.Parameters.Clear();
                cmd.Dispose();
                disconnect_db();
            }
        }


    }

   

    
}
