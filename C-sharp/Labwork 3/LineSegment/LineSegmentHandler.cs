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
    }
}
