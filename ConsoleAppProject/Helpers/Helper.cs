using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppProject.Helpers
{
    public static class Helper
    {
        public static bool IsCapitalizedNameAndSurname(this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return false;
            if (str.Split(" ").Length > 1)
                return false;
            if (str.Length < 3)
                return false;
            return char.IsUpper(str[0]);
        }
        public static bool IsValidClassroomName(this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return false;
            if (str.Length != 5)
                return false;
            if (!char.IsLetter(str[0]) || !char.IsLetter(str[1]) || !char.IsDigit(str[2]) || !char.IsDigit(str[3]) || !char.IsDigit(str[4]))
                return false;
            if (str[0] != char.ToUpper(str[0]) || str[1] != char.ToUpper(str[1]))
                return false;
            return true;
        } 
    }
}
