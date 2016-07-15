using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6_2
{
    public class StringConverter
    {
        public bool TryConvertToInt(string str, out int number)
        {
            number = 0;
            if (str == null || !str.Any())
                return false;

            bool isNegative = false;
            if (str[0] == '-')
            {
                isNegative = true;
                str = str.Substring(1, str.Length - 1);
            }
            else if (str[0] == '+')
            {
                str = str.Substring(1, str.Length - 1);
            }

            if (!str.All(char.IsDigit))
            {
                return false;
            }

            long factor = 1;
            long num = 0;
            for (int i = str.Length - 1; i >= 0; i--)
            {
                if (factor > int.MaxValue)
                    return false;
                if (isNegative)
                    num -= (str[i] - '0') * factor;
                else
                    num += (str[i] - '0') * factor;
                if (num > int.MaxValue || num < int.MinValue)
                    return false;
                factor *= 10;
            }
            number = (int)num;

            return true;
        }

        public int ConvertToInt(string str)
        {
            int number = 0;

            if (str == null)
                throw new ArgumentNullException();

            if (!str.Any())
                throw new FormatException();

            bool isNegative = false;
            if (str[0] == '-')
            {
                isNegative = true;
                str = str.Substring(1, str.Length - 1);
            }
            else if (str[0] == '+')
            {
                str = str.Substring(1, str.Length - 1);
            }

            if (!str.All(char.IsDigit))
            {
                throw new FormatException();
            }

            //overflow check
            checked
            {
                int factor = 1;
                bool firstTime = true;
                for (int i = str.Length - 1; i >= 0; i--)
                {
                    if(!firstTime)
                        factor *= 10;
                    if (isNegative)
                        number -= (str[i] - '0') * factor;
                    else
                        number += (str[i] - '0') * factor;
                    firstTime = false;
                }
            }

            return number;
        }
    }
}
