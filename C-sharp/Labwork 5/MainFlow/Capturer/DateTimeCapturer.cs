namespace Labwork_5.MainFlow.Capturer
{
    public class DateTimeCapturer
    {
        public static TimeOnly CaptureTime()
        {
            TimeOnly time = new TimeOnly();
            bool valueIsValid = false;

            while (!valueIsValid)
            {
                valueIsValid = true;

                try
                {
                    System.Console.Write("Please, enter the time: ");
                    time = TimeOnly.Parse(Console.ReadLine());
                }
                catch (FormatException ex)
                {
                    System.Console.WriteLine(ex.Message);
                    valueIsValid = false;
                }
            }

            return time;
        }

        public static DateOnly CaptureDate()
        {
            DateOnly date = new DateOnly();
            bool valueIsValid = false;

            while (!valueIsValid)
            {
                valueIsValid = true;

                try
                {
                    System.Console.Write("Please, enter the date: ");
                    date = DateOnly.Parse(Console.ReadLine());
                }
                catch (FormatException ex)
                {
                    System.Console.WriteLine(ex.Message);
                    valueIsValid = false;
                }
            }

            return date;
        }
    }
}