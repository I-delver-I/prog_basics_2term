using System;
using Labwork_3.LineSegment;

namespace Labwork_3.MainFlow
{
    static class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please, enter values to create three line segments:\n");

            LineSegmentModel firstLineSegment = DataCapturer.CaptureLineSegment();
            Console.WriteLine($"The first line segment was created successfully! {Environment.NewLine}");
            PrintDashLine();

            LineSegmentModel secondLineSegment = new LineSegmentModel();
            Console.WriteLine($"The second default (P1(1 ; 1), P2(0 ; 0)) line segment was created! {Environment.NewLine}");
            PrintDashLine();

            LineSegmentModel thirdLineSegment = DataCapturer.CaptureLineSegment();
            Console.WriteLine($"The third line segment was created successfully! {Environment.NewLine}");
            PrintDashLine();

            DataChecker.CheckForLinesParallelism(firstLineSegment, secondLineSegment);
            Console.WriteLine($"The third line segment {++thirdLineSegment} was successfully incremented! {Environment.NewLine}");

            Console.WriteLine($"The length of the third line segment is " +
                $"{LineSegmentHandler.GetLineSegmentLength(thirdLineSegment)}");
        }

        static void PrintDashLine()
        {
            Console.WriteLine($"{new string('-', 40)}");
        }
    }
}
