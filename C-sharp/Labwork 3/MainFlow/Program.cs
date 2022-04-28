using System;
using Labwork_3.LineSegment;

namespace Labwork_3.MainFlow
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please, enter values to create three line segments:\n");

            LineSegmentModel firstLineSegment = DataCapturer.CaptureLineSegmentSpecifyingTwoPoints();
            Console.WriteLine($"The first line segment was created successfully! { Environment.NewLine }");

            LineSegmentModel secondLineSegment = DataCapturer.CaptureLineSegmentSpecifyingOnePoint();
            Console.WriteLine($"The second line segment was created successfully! { Environment.NewLine }");

            LineSegmentModel thirdLineSegment = new LineSegmentModel();
            Console.WriteLine(Environment.NewLine);

            DataChecker.CheckForLinesParallelism(firstLineSegment, secondLineSegment);
            Console.WriteLine($"The line segment { ++thirdLineSegment } was successfully incremented!");

            Console.WriteLine($"The length of the third line segment is " +
                $"{ LineSegmentHandler.GetLineSegmentLength(thirdLineSegment) }");
        }
    }
}
