using System;
using System.Collections.Generic;
using System.Linq;

namespace Labwork_1._2.Handlers
{
    struct DateHandler
    {
        public static int CountDaysBySubtractingDates(string firstDate, string secondDate)
        {
            List<string> firstDateAsNumbers = firstDate.Split('-').ToList();
            List<string> secondDateAsNumbers = secondDate.Split('-').ToList();
            int daysCount = 0;

            daysCount += Math.Abs(int.Parse(firstDateAsNumbers[0]) - int.Parse(secondDateAsNumbers[0]));        // Day
            daysCount += Math.Abs(int.Parse(firstDateAsNumbers[1]) - int.Parse(secondDateAsNumbers[1])) * 30;   // Month
            daysCount += Math.Abs(int.Parse(firstDateAsNumbers[2]) - int.Parse(secondDateAsNumbers[2])) * 365;  // Year

            return daysCount;
        }
    }
}
