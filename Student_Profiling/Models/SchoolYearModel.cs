using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Student_Profiling.Models
{
    class SchoolYearModel:DBConnection
    {

        public SchoolYearObj GetCurSchoolYear()
        {
            var sy = new SchoolYearObj();
            try
            {
                connect();
                cmd.CommandText = "SELECT syID, description, sem from tbl_sy WHERE status = true";
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    sy.syID = reader.GetString("syID");
                    sy.SchoolYear = reader.GetString("description");
                    sy.Sem = reader.GetString("sem");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            } finally
            {
                cmd.Dispose();
                reader.Dispose();
                disconnect_db();
            }
            return sy;
        }


        public DataTable GetSchoolerYearList()
        {
            DataTable dt = new DataTable();
            try
            {
                connect();
                cmd.CommandText = "SELECT * FROM tbl_sy WHERE deleted = false ";
                reader = cmd.ExecuteReader();
                dt.Load(reader);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }finally
            {
                cmd.Dispose();
                reader.Dispose();
                disconnect_db();

            }
            return dt;
        }
        public bool insert(SchoolYearObj sy)
        {
            try
            {
                connect();
                cmd.CommandText = "INSERT INTO tbl_sy(description, sem) VALUES (@Description, @Sem)";
                cmd.Parameters.AddWithValue("@Description", sy.SchoolYear);
                cmd.Parameters.AddWithValue("@Sem", sy.Sem);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                cmd.Parameters.Clear();
                cmd.Dispose();
                disconnect_db();
            }
        }

        public bool update(SchoolYearObj sy)
        {
            try
            {
                connect();
                cmd.CommandText = "UPDATE tbl_sy SET description = @Description, sem = @Sem WHERE syID = @syID";
                cmd.Parameters.AddWithValue("@Description", sy.SchoolYear);
                cmd.Parameters.AddWithValue("@Sem", sy.Sem);
                cmd.Parameters.AddWithValue("@syID", sy.syID);
                cmd.ExecuteNonQuery();
                return true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;

            }
            finally
            {
                cmd.Parameters.Clear();
                cmd.Dispose();
                disconnect_db();
            }
        }
        public bool SetDeativeSY(string syID)
        {
            try
            {
                connect();
               
                cmd.CommandText = $"UPDATE tbl_sy set status = false WHERE syID = {syID}";
                cmd.ExecuteNonQuery();
                return true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                cmd.Dispose();
                disconnect_db();
            }
        }

        public bool delete(string syID)
        {
            try
            {
                connect();

                cmd.CommandText = $"UPDATE tbl_sy set deleted = true WHERE syID = {syID}";
                cmd.ExecuteNonQuery();
                return true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                cmd.Dispose();
                disconnect_db();
            }
        }
        public bool SetActiveSY(string syID)
        {
            try
            {
                connect();
                transact = con.BeginTransaction();
                cmd.Transaction = transact;
                cmd.CommandText = "UPDATE tbl_sy set status = false";
                cmd.ExecuteNonQuery();

                cmd.CommandText = $"UPDATE tbl_sy set status = true WHERE syID = {syID}";
                cmd.ExecuteNonQuery();
                transact.Commit();
                return true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }finally
            {
                cmd.Dispose();
                disconnect_db();
            }
        }
    }

    class SchoolYearObj
    {
        public string syID { get; set; }
        public string SchoolYear { get; set; }
        public string Sem { get; set; }
        public bool Status { get; set; }
    }
}
