﻿
using System;

namespace Labwork_3
{
    public class LineSegment
    {
        public Point BeginPoint { get; set; }
        public Point EndPoint { get; set; }

        public LineSegment(Point beginPoint, Point endPoint)
        {
            BeginPoint = beginPoint;
            EndPoint = endPoint;
        }

        public LineSegment(Point sharedPoint)
        {
            BeginPoint = new Point(sharedPoint.Xaxis);
            EndPoint = new Point(sharedPoint.Yaxis);
        }

        public LineSegment()
        {
            BeginPoint = new Point(1);
            EndPoint = new Point(0);
        }

        public static LineSegment operator ++(LineSegment lineSegment)
        {
            ++lineSegment.BeginPoint;
            return lineSegment;
        }

        public static bool operator |(LineSegment firstSegment, LineSegment secondSegment)
        {
            // P1(a1, b1), P2(c1, d1), P3(a2, b2), P4(c2, d2)
            double a1 = firstSegment.BeginPoint.Xaxis;
            double b1 = firstSegment.BeginPoint.Yaxis;
            double c1 = firstSegment.EndPoint.Xaxis;
            double d1 = firstSegment.EndPoint.Yaxis;
            double a2 = secondSegment.BeginPoint.Xaxis;
            double b2 = secondSegment.BeginPoint.Yaxis;
            double c2 = secondSegment.EndPoint.Xaxis;
            double d2 = secondSegment.EndPoint.Yaxis;

            // The first condition of parallelism of line segments
            if ((a1 == c1 && a2 == c2) || (b1 == d1 && b2 == d2))
            {
                return true;
            }

            double m1 = (d1 - b1) / (c1 - a1);
            double m2 = (d2 - b2) / (c2 - a2);

            // The second condition of parallelism of line segments
            if (m1 == m2)
            {
                return true;
            }

            return false;
        }

        public static double GetLineSegmentLength(LineSegment lineSegment)
        {
            // sqrt((x1-x2)^2 + (y1-y2)^2)
            return Math.Sqrt(Math.Pow(lineSegment.BeginPoint.Xaxis - lineSegment.EndPoint.Xaxis, 2)
                + Math.Pow(lineSegment.BeginPoint.Yaxis - lineSegment.EndPoint.Yaxis, 2));
        }

        public static bool LineSegmentIsValid(LineSegment lineSegment)
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

        public override string ToString()
        {
            return $"BeginPoint: Xaxis - { BeginPoint.Xaxis }, Yaxis - { BeginPoint.Yaxis };" +
                $" EndPoint: Xaxis - { EndPoint.Xaxis }, Yaxis - { EndPoint.Yaxis }";
        }
    }
}