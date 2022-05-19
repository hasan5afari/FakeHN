using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeHN.Entities
{
    public partial class Utilities
    {

        public static string parseDate(string date)
        {
            string newDate = "";

            if (date[1] == '/')
            {
                newDate += "0" + date[0] + "/";
                date = date.Substring(2);
            }
            else
            {
                newDate += date.Substring(0, 2) + "/";
                date = date.Substring(3);
            }

            if (date[1] == '/')
            {
                newDate += "0" + date[0] + "/";
                date = date.Substring(2);
            }
            else
            {
                newDate += date.Substring(0, 2) + "/";
                date = date.Substring(3);
            }

            newDate += date;

            return newDate;
        }

        public static bool isValidName(string value)
        {
            if (!string.IsNullOrEmpty(value) && !value.Contains(" ") && value.Trim().Length != 0)
                return true;
            else
                return false;
        }
    }
}
