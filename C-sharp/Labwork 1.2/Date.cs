using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Labwork_1_2
{
    [Serializable]
    struct Date
    {
        private static Regex _datePattern = new Regex(@"[0-3]{1}[0-9]{1}-(0|1){1}[0-9]{1}-\d{4}$");

        private string _creationDate;
        public string CreationDate
        {
            get
            {
                return _creationDate;
            }
            set
            {
                if (_datePattern.IsMatch(value))
                {
                    _creationDate = value;
                }
                else
                {
                    throw new ArgumentException("The entered creation date isn't valid");
                }
            }
        }

        private string _expirationDate;
        public string ExpirationDate
        {
            get
            {
                return _expirationDate;
            }
            set
            {
                if (_datePattern.IsMatch(value))
                {
                    _expirationDate = value;
                }
                else
                {
                    throw new ArgumentException("The entered expiration date isn't valid");
                }
            }
        }

        private static string _currentDate;
        public static string CurrentDate 
        {
            get
            {
                return _currentDate;
            }
            set
            {
                if (_datePattern.IsMatch(value))
                {
                    _currentDate = value;
                }
                else
                {
                    throw new ArgumentException("The entered current date isn't valid");
                }
            }
        }

        public int CountDaysBySubstractingDates(string firstDate, string secondDate)
        {
            List<string> firstDateAsNumbers = firstDate.Split('-').ToList();
            List<string> secondDateAsNumbers = secondDate.Split('-').ToList();
            int daysCount = 0;

            daysCount += Math.Abs(int.Parse(firstDateAsNumbers[0]) - int.Parse(secondDateAsNumbers[0]));    // Day
            daysCount += Math.Abs(int.Parse(firstDateAsNumbers[1]) - int.Parse(secondDateAsNumbers[1])) * 30;   // Month
            daysCount += Math.Abs(int.Parse(firstDateAsNumbers[2]) - int.Parse(secondDateAsNumbers[2])) * 365;  // Year
            
            return daysCount;
        }
    }
}
