using System;

namespace Labwork_3.MainFlow
{
    public static class DataChecker
    {
        public static void CheckForLinesParallelism(LineSegment firstSegment, LineSegment secondSegment)
        {
            if (firstSegment | secondSegment)
            {
                Console.WriteLine("The first and second line segments are parallel!\n");
            }
            else
            {
                Console.WriteLine("The first and second line segments are NOT parallel!\n");
            }
        }
    }
}
