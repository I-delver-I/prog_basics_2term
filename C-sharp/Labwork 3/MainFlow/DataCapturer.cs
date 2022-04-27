using System;
using System.Collections.Generic;
using Labwork_3.LineSegment;

namespace Labwork_3.MainFlow
{
    public static class DataCapturer
    {
        public static LineSegmentModel CaptureLineSegmentSpecifyingTwoPoints()
        {
            return new LineSegmentModel(CapturePoint(), CapturePoint());
        }

        public static Point CapturePoint()
        {
            bool exceptionIsCaught;
            Point newPoint;

            do
            {
                exceptionIsCaught = false;
                newPoint = new Point();

                try
                {
                    Console.Write($"Please, enter value for X axis for the point: ");
                    newPoint.Xaxis = Convert.ToDouble(Console.ReadLine());

                    Console.Write($"Please, enter value for Y axis for the point: ");
                    newPoint.Yaxis = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("The point was created successfully!\n");
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(Environment.NewLine);
                    exceptionIsCaught = true;
                }
                catch (IndexOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(Environment.NewLine);
                    exceptionIsCaught = true;
                }
            } while (exceptionIsCaught);

            return newPoint;
        }

        public static LineSegmentModel CaptureLineSegmentSpecifyingOnePoint()
        {
            return new LineSegmentModel(CapturePoint());
        }
    }
}
