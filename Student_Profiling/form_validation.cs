using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Student_Profiling
{
    class form_validation
    {

        public form_validation()
        {

        }

        public bool valid_email(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public bool numeric(string number)
        {
            return Regex.Match(number, "^[0-9]+$").Success;
        }

        public bool min_length(string number, int length)
        {
            return (number.Length < length) ? false : true;
        }

        public bool max_length(string number, int length)
        {
            return (number.Length > length) ? false : true;
        }

        public bool required(string field)
        {
            return (string.IsNullOrEmpty(field)) ? false : true;
        }


    }
}
