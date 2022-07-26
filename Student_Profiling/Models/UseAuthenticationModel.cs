using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Student_Profiling.Models
{
    class UseAuthenticationModel:DBConnection
    {
        public bool ChechUserAcc(string Username, string Password)
        {
            var encrypt = new PasswordEncryptModel(Password);
            bool status = false;
            string EncryptedPassword = Convert.ToBase64String(encrypt.EncryptStringToBytes_Aes());

            try
            {
                connect();
                cmd.CommandText = "SELECT * FROM tbl_user WHERE username = @UserName";
                cmd.Parameters.AddWithValue("@UserName", Username);
                reader = cmd.ExecuteReader();
                if(reader.HasRows)
                {
                    while (reader.Read())
                    {
                        if(EncryptedPassword == reader.GetString("password"))
                        {
                            status =  true;
                        }
                    }
                }
                return status;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
