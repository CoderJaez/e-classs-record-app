using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Student_Profiling.Models
{
    class CourseModel:DBConnection
    {
        private int start;
        private int limit = 10;
        private string search;
        public bool insert(Course obj)
        {
            bool result;
            try
            {
                connect();
                cmd.CommandText = "INSERT INTO tbl_course (courseCode,courseDesc) VALUES (@CourseCode, @Description)";
                cmd.Parameters.AddWithValue("@CourseCode", obj.CourseCode);
                cmd.Parameters.AddWithValue("@Description", obj.Description);
                cmd.ExecuteNonQuery();
                result = true;
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message , "WMSU-ESU PAGADIAN");
                result = false;
            }
            finally
            {
                cmd.Parameters.Clear();
                cmd.Dispose();
                disconnect_db();
            }
            return result;
           
        }

        public bool update(Course obj)
        {
            try
            {
                connect();
                cmd.CommandText = "UPDATE tbl_course SET courseCode = @CourseCode, courseDesc = @Descripion WHERE courseID = @CourseID";
                cmd.Parameters.AddWithValue("@CourseCode", obj.CourseCode);
                cmd.Parameters.AddWithValue("@Descripion", obj.Description);
                cmd.Parameters.AddWithValue("@CourseID", obj.CourseID);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "WMSU-ESU PAGADIAN!");
                return false;
            }
            finally
            {
                cmd.Parameters.Clear();
                cmd.Dispose();
                disconnect_db();
            }
        }

        public IList<Course> getCourseList(int _start,int _limit,string _search)
        {
            search = _search;
            start = _start;
            limit = _limit;
            var courseList = new List<Course>();
            try
            {
                connect();
                cmd.CommandText = "SELECT courseID, courseCode, courseDesc FROM tbl_course WHERE deleted = false AND (courseCode LIKE @CourseCode OR courseDesc LIKE @Description) LIMIT @start,@limit ";
                cmd.Parameters.AddWithValue("@CourseCode", $"%{search}%");
                cmd.Parameters.AddWithValue("@Description", $"%{search}%");
                cmd.Parameters.AddWithValue("@start", start);
                cmd.Parameters.AddWithValue("@limit", limit);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var course = new Course();
                    course.CourseID = reader.GetInt32("courseID");
                    course.CourseCode = reader.GetString("courseCode");
                    course.Description = reader.GetString("courseDesc");
                    courseList.Add(course);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "WMSU-ESU PAGADIAN!");
            } finally
            {
                cmd.Parameters.Clear();
                cmd.Dispose();
                reader.Dispose();
                disconnect_db();
            }

            return courseList;
        }

        public int filtered_data()
        {
            try
            {
                connect();
                cmd.CommandText = "SELECT count(*) AS filtered_data FROM tbl_course WHERE deleted = false AND (courseCode LIKE @CourseCode OR courseDesc LIKE @Description) LIMIT @start,@limit ";
                cmd.Parameters.AddWithValue("@CourseCode", $"%{search}%");
                cmd.Parameters.AddWithValue("@Description", $"%{search}%");
                cmd.Parameters.AddWithValue("@start", start);
                cmd.Parameters.AddWithValue("@limit", limit);
                reader = cmd.ExecuteReader();
                return (reader.Read()) ? reader.GetInt32("filtered_data") : 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "WMSU-ESU PAGADIAN");
                return 0;
            } finally
            {
                cmd.Parameters.Clear();
                cmd.Dispose();
                reader.Dispose();
                disconnect_db();
            }
        }

        public int totalRows()
        {
            try
            {
                connect();
                cmd.CommandText = "SELECT COUNT(*) AS total FROM tbl_course WHERE deleted = false";
                reader = cmd.ExecuteReader();
                return (reader.Read()) ? Convert.ToInt32(reader["total"].ToString()) : 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
            finally
            {
                reader.Close();
                reader.Dispose();
                cmd.Dispose();
                disconnect_db();
            }
        }


        public bool delete(int courseID)
        {
            try
            {
                connect();
                cmd.CommandText = "UPDATE tbl_course SET delete = true where courseID = @CourseID";
                cmd.Parameters.AddWithValue("@CourseID", courseID);
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

        public bool delete_batch(List<string> courseIDs)
        {
            string qry = "UPDATE `tbl_course` SET ";
            string idlist = "";
            foreach (var id in courseIDs)
            {
                qry += $"`deleted` = CASE WHEN `courseID` = '{id}' THEN true ELSE deleted END,";
                idlist += $"'{id}',";
            }
            idlist = idlist.Remove(idlist.Length - 1, 1);
            qry = qry.Remove(qry.Length - 1, 1);
            qry += $" WHERE courseID IN({idlist})";
            try
            {
                connect();
                cmd.CommandText = qry;
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
                cmd.Dispose();
                disconnect_db();
            }
        }


        //Check Course Code Duplication
        public bool validateCourseCode(string CourseCode,int courseID)
        {
            string query;
            if(courseID != 0)
                query = $"SELECT * FROM tbl_course WHERE deleted = false AND courseCode = '{CourseCode}' AND courseID != {courseID}";
            else
                query = $"SELECT * FROM tbl_course WHERE deleted = false AND courseCode = '{CourseCode}'";
            try
            {
                connect();
                cmd.CommandText = query;
                reader = cmd.ExecuteReader();
                return reader.HasRows;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "WMSU-ESU PAGADIAN");
                return false;
            }
            finally
            {
                disconnect_db();
            }
        }
    }

    public class Course
    {
        public int CourseID { get; set; }
        public string CourseCode { get; set; }
        public string Description { get; set; }
    }
}
