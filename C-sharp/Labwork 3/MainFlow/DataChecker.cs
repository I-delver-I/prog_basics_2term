using System;
using System.Collections.Generic;
using System.Text;
using Labwork_3.LineSegment;

namespace Labwork_3.MainFlow
{
    public class DataChecker
    {
        public static void CheckForLinesParallelism(LineSegmentModel firstSegment, LineSegmentModel secondSegment)
        {
            if (firstSegment | secondSegment)
            {
                Console.WriteLine("The first and second line segments are parallel!\n");
            }
            else
            {
                Console.WriteLine("The first and second line segments are not parallel!\n");
            }
        }
    }
}
