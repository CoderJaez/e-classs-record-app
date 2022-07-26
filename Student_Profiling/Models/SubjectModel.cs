using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Student_Profiling.Objects;

namespace Student_Profiling.Models
{
    class SubjectModel:DBConnection
    {

        public bool insert(Subject subj)
        {
            try
            {
                connect();
                cmd.CommandText = "INSERT INTO tbl_subject (subjID,courseCode,subjCode,subjDesc,lec,lab,year,sem) VALUES (@SubjectID, @CourseCode, @SubjectCode, @SubjectDesc,@Lec,@Lab,@Year,@Sem)";
                cmd.Parameters.AddWithValue("@SubjectID", subj.SubjectID);
                cmd.Parameters.AddWithValue("@CourseCode",subj.CourseCode);
                cmd.Parameters.AddWithValue("@SubjectCode",subj.SubjectCode);
                cmd.Parameters.AddWithValue("@SubjectDesc",subj.Description);
                cmd.Parameters.AddWithValue("@Lec",subj.Lecture);
                cmd.Parameters.AddWithValue("@Lab",subj.Lab);
                cmd.Parameters.AddWithValue("@Year", subj.year);
                cmd.Parameters.AddWithValue("@Sem", subj.sem);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "WMSU-ESU PAGADIAN");
                return false;
            }finally
            {
                cmd.Parameters.Clear();
                cmd.Dispose();
                disconnect_db();
            }
        }

        public bool update(Subject subj)
        {
            try
            {
                connect();
                cmd.CommandText = "UPDATE tbl_subject SET  subjCode=@SubjectCode, subjDesc=@SubjectDesc, lec=@Lec, lab = @Lab,year=@Year,sem =@Sem WHERE subjID = @SubjectID";
                cmd.Parameters.AddWithValue("@SubjectID", subj.SubjectID);
                cmd.Parameters.AddWithValue("@SubjectCode", subj.SubjectCode);
                cmd.Parameters.AddWithValue("@SubjectDesc", subj.Description);
                cmd.Parameters.AddWithValue("@Lec", subj.Lecture);
                cmd.Parameters.AddWithValue("@Lab", subj.Lab);
                cmd.Parameters.AddWithValue("@Year", subj.year);
                cmd.Parameters.AddWithValue("@Sem", subj.sem);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "WMSU-ESU PAGADIAN");
                return false;
            }
            finally
            {
                cmd.Parameters.Clear();
                cmd.Dispose();
                disconnect_db();
            }
        }

        public bool delete(string subjectID)
        {
            try
            {
                connect();
                cmd.CommandText = "UPDATE tbl_subject SET deleted = true WHERE subjID = @SubjectID";
                cmd.Parameters.AddWithValue("@SubjectID",subjectID);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "WMSU-ESU PAGADIAN");
                return false;
            }
            finally
            {
                cmd.Parameters.Clear();
                cmd.Dispose();
                disconnect_db();
            }
        }

        public bool deleteBatch(List<string> _SubjectIDList)
        {
            bool result;
            string qry = "UPDATE `tbl_subject` SET ";
            string SubjectIDList = "";
            foreach (var id in _SubjectIDList)
            {
                qry += $"`deleted` = CASE WHEN `subjID` = '{id}' THEN true ELSE deleted END,";
                SubjectIDList += $"'{id}',";
            }
            SubjectIDList = SubjectIDList.Remove(SubjectIDList.Length - 1, 1);
            qry = qry.Remove(qry.Length - 1, 1);
            qry += $" WHERE subjID IN({SubjectIDList})";
            try
            {
                connect();
                cmd.CommandText = qry;
                cmd.ExecuteNonQuery();
                result = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message , "WMSU-ESU PAGADIAN");
                result = false;

            }
            finally
            {
                cmd.Dispose();
                disconnect_db();
            }


            return result;
        }

        public IList<Subject> getSlistOfSubjectsForEnlistment(string search, string _where, string sem)
        {
            var SubjectList = new List<Subject>();
            try
            {
                connect();
                cmd.CommandText = $"SELECT subjID,subjCode,subjDesc, lab, lec,year from tbl_subject where deleted = false {_where} AND sem = @Sem AND (subjID LIKE @SubjectID OR subjDesc LIKE @Description OR subjCode LIKE @SubjectCode);";
                cmd.Parameters.AddWithValue("@Sem", sem);
                cmd.Parameters.AddWithValue("@SubjectID", $"%{search}%");
                cmd.Parameters.AddWithValue("@SubjectCode", $"%{search}%");
                cmd.Parameters.AddWithValue("@Description", $"%{search}%");

                reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    var subj = new Subject();
                    subj.SubjectID = reader.GetString("subjID");
                    subj.SubjectCode = reader.GetString("subjCode");
                    subj.Description = reader.GetString("subjDesc");
                    subj.Lab = reader.GetString("lab");
                    subj.Lecture = reader.GetString("lec");
                    subj.year = reader.GetString("year");
                    SubjectList.Add(subj);
                }
          
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            } finally
            {
                cmd.Parameters.Clear();
                cmd.Dispose();
                reader.Dispose();
                disconnect_db();
            }

            return SubjectList;
        }

        public IList<Subject> getListOfSubjects(string CourseCode, string _search)
        {
            var SubjectList = new List<Subject>();
            try
            {
                connect();
                cmd.CommandText = "SELECT subjID,subjCode,subjDesc,lec,lab,year,sem FROM tbl_subject WHERE courseCode = @CourseCode AND deleted = false AND (subjCode LIKE @SubjectCode OR subjDesc LIKE @SubjectDesc)";
                cmd.Parameters.AddWithValue("@CourseCode", CourseCode);
                cmd.Parameters.AddWithValue("@SubjectCode", $"%{_search}%");
                cmd.Parameters.AddWithValue("@SubjectDesc", $"%{_search}%");
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var obj = new Subject();
                    obj.SubjectID = reader.GetString("subjID");
                    obj.SubjectCode = reader.GetString("subjCode");
                    obj.Description = reader.GetString("subjDesc");
                    obj.Lecture = reader.GetString("lec");
                    obj.Lab = reader.GetString("lab");
                    obj.year = reader.GetString("year");
                    obj.sem = reader.GetString("sem");
                    SubjectList.Add(obj); 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message , "WMSU-ESU PAGADIAN");
            }finally
            {
                cmd.Parameters.Clear();
                cmd.Dispose();
                reader.Dispose();
                disconnect_db();
            }

            return SubjectList;
        }

        public string GetSubjetID(string CourseCode)
        {
            string SubjectID ="";
            string test=null;
            
            try
            {
                connect();
                cmd.CommandText = $"SELECT subjID FROM tbl_subject where courseCode = '{CourseCode}' ORDER BY subjID DESC LIMIT 1";
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    test = reader.GetString("subjID");
                    SubjectID = reader.GetString("subjID");
                    SubjectID = Regex.Replace(SubjectID, "[A-Za-z]", "");
                    SubjectID = (Convert.ToInt32(SubjectID) + 1).ToString();
                } else
                {
                    SubjectID = "10001";
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + $"\n{test}", "WMSU - ESU PAGADIAN");
                
            } finally
            {
                cmd.Dispose();
                reader.Dispose();
                disconnect_db();
            }
            return SubjectID;
        }



        public bool ValidateSubject(string SubjectCode, string SubjectID = null)
        {
            try
            {
                connect();
                if (SubjectID != null)
                {
                    cmd.CommandText = "SELECT * FROM tbl_subject WHERE deleted = false AND subjCode = @SubjectCode AND subjID != @SubjectID";
                    cmd.Parameters.AddWithValue("@SubjectCode", SubjectCode);
                    cmd.Parameters.AddWithValue("@SubjectID", SubjectID);
                } else
                {
                    cmd.CommandText = "SELECT * FROM tbl_subject WHERE deleted = false AND subjCode = @SubjectCode";
                    cmd.Parameters.AddWithValue("@SubjectCode", SubjectCode);
                }
                reader = cmd.ExecuteReader();
                return reader.HasRows;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "WMSU-ESU PAGADIAN");
                return false;
            } finally
            {
                cmd.Parameters.Clear();
                cmd.Dispose();
                reader.Dispose();
                disconnect_db();
            }

        }
    }

    
}
