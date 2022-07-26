using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Student_Profiling
{
    class Programs_m : DBConnection
    {
        private int start = 0;
        private int limit = 5;
        private string colDesc = "";
        public bool addProgram(program prg)
        {
            bool result;
            try
            {
                connect();
                cmd.CommandText = "INSERT INTO tbl_colleges (colCode, colDesc) VALUES(@colCode,@colDesc)";
                cmd.Parameters.AddWithValue("@colCode", prg.ID);
                cmd.Parameters.AddWithValue("@colDesc", prg.Programs);
                cmd.ExecuteNonQuery();
                result = true;
            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "WMSU-ESU PAGADIAN");
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

        public bool deleteProgramBatch(List<string> idList)
        {
            bool result;
            string qry = "UPDATE `tbl_colleges` SET ";
            string idlist = "";
            foreach(var id in idList)
            {
                qry += $"`deleted` = CASE WHEN `colCode` = '{id}' THEN true ELSE deleted END,";
                idlist += $"'{id}',";
            }
            idlist = idlist.Remove(idlist.Length - 1, 1);
            qry = qry.Remove(qry.Length - 1, 1);
            qry += $" WHERE colCode IN({idlist})";
            try
            {
                connect();
                cmd.CommandText = qry;
                cmd.ExecuteNonQuery();
                result = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + Environment.NewLine + qry, "WMSU-ESU PAGADIAN");
                result = false;

            }
            finally
            {
                cmd.Dispose();
                disconnect_db();
            }


            return result;
        }



        public bool deleteProgram(string colCode)
        {
            bool result;
            try
            {
                connect();
                cmd.CommandText = "UPDATE tbl_colleges SET deleted = true where colCode = @colCode";
                cmd.Parameters.AddWithValue("@colCode", colCode);
                cmd.ExecuteNonQuery();
                result = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "WMSU-ESU PAGADIAN");
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


        
        public bool updateProgram(program prg)
        {
            bool result;
            try
            {
                connect();
                cmd.CommandText = "UPDATE tbl_colleges SET colDesc = @colDesc where colCode = @colCode";
                cmd.Parameters.AddWithValue("@colCode", prg.ID);
                cmd.Parameters.AddWithValue("@colDesc", prg.Programs);
                cmd.ExecuteNonQuery();
                result = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "WMSU-ESU PAGADIAN");
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

        public String getcolCode()
        {
            try
            {
                connect();
                cmd.CommandText = "SELECT colCode FROM tbl_colleges ORDER BY colCode DESC LIMIT 1";
                reader = cmd.ExecuteReader();
                return (reader.Read()) ? Convert.ToString(Convert.ToInt32(reader["colCode"].ToString()) + 1) : "100001";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return "null";
            }
            finally
            {
                reader.Close();
                reader.Dispose();
                cmd.Dispose();
                disconnect_db();
            }
        }

        public int totalRows()
        {
            try
            {
                connect();
                cmd.CommandText = "SELECT COUNT(*) AS total FROM tbl_colleges WHERE deleted = false";
                reader = cmd.ExecuteReader();
                return (reader.Read()) ? Convert.ToInt32(reader["total"].ToString())  : 0;
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


        public int filtered_data()
        {
            try
            {
                connect();
                cmd.CommandText = "SELECT COUNT(*) AS filtered_data FROM tbl_colleges where deleted = false AND colDesc LIKE @colDesc LIMIT @start,@limit";
                cmd.Parameters.AddWithValue("@start", start);
                cmd.Parameters.AddWithValue("@limit", limit);
                cmd.Parameters.AddWithValue("@colDesc", $"%{colDesc}%");
                reader = cmd.ExecuteReader();
                return (reader.Read()) ? Convert.ToInt32(reader["filtered_data"].ToString()) : 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
            finally
            {
                cmd.Parameters.Clear();
                reader.Close();
                reader.Dispose();
                cmd.Dispose();
                disconnect_db();
            }
        }


        public IList<program> getProgramlist(int _limit,int _start,string _colDesc)
        {
            start = _start;
            limit = _limit;
            colDesc = _colDesc;
            var prg = new List<program>();
            try
            {
                connect();
                cmd.CommandText = "SELECT colCode, colDesc FROM tbl_colleges where deleted = false AND colDesc LIKE @colDesc LIMIT @start,@limit";
                cmd.Parameters.AddWithValue("@start", _start);
                cmd.Parameters.AddWithValue("@limit", _limit);
                cmd.Parameters.AddWithValue("@colDesc", $"%{colDesc}%");
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    program pr = new program();
                    pr.ID = reader.GetString("colCode");
                    pr.Programs = reader.GetString("colDesc");
                    prg.Add(pr);
                }
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "WMSU-ESU PAGADIAN!");

            } finally
            {
                cmd.Parameters.Clear();
                cmd.Dispose();
                reader.Dispose();
                disconnect_db();
            }
            return prg;
        }
    }

    public class program
    {
        public string ID { get; set; }
        public string Programs { get; set; }
    }
    

}
