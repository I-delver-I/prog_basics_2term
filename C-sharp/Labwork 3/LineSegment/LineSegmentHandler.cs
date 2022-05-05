using System;

namespace Labwork_3.LineSegment
{
    public static class LineSegmentHandler
    {
        public static double GetLineSegmentLength(LineSegmentModel lineSegment)
        {
            // sqrt((x1-x2)^2 + (y1-y2)^2)
            return Math.Sqrt(Math.Pow(lineSegment.BeginPoint.Xaxis - lineSegment.EndPoint.Xaxis, 2)
                + Math.Pow(lineSegment.BeginPoint.Yaxis - lineSegment.EndPoint.Yaxis, 2));
        }

        public static bool CheckLineSegmentIsValid(LineSegmentModel lineSegment)
        {
            try
            {
                if (lineSegment.BeginPoint == lineSegment.EndPoint)
                {
                    throw new ArgumentException("The line segment length should be more than 0");
                }

                return true;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
