using System;

namespace Labwork_3.MainFlow
{
    public static class DataCapturer
    {
        public static LineSegment CaptureLineSegment()
        {
            LineSegment result = new LineSegment();
            bool exceptionIsThrown;

            do
            {
                try
                {
                    exceptionIsThrown = false;

                    Console.WriteLine("Please, choose the count of points you are able to enter:");
                    int count = Convert.ToInt32(Console.ReadLine());

                    result = count switch
                    {
                        1 => new LineSegment(CapturePoint()),
                        2 => new LineSegment(CapturePoint(), CapturePoint()),
                        _ => throw new ArgumentException("Please, enter 1 or 2 points to capture"),
                    };

                    if (!LineSegment.LineSegmentIsValid(result))
                    {
                        exceptionIsThrown = true;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("You entered not a number");
                    exceptionIsThrown = true;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    exceptionIsThrown = true;
                }
                
            } while (exceptionIsThrown);

            return result;
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
                catch (FormatException)
                {
                    Console.WriteLine("You entered not a number");
                    exceptionIsCaught = true;
                }
                catch (IndexOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message);
                    exceptionIsCaught = true;
                }
            } while (exceptionIsCaught);

            return newPoint;
        }
    }
}
