namespace Labwork_5.MainFlow.Capturer
{
    public class DateTimeCapturer
    {
        public static DateTime CaptureDateAndTime()
        {
            DateTime result = new DateTime();
            bool valueIsValid = false;

            while (!valueIsValid)
            {
                valueIsValid = true;

                try
                {
                    System.Console.Write("Please, enter the time: ");
                    TimeOnly time = TimeOnly.Parse(Console.ReadLine());

                    result = CaptureDate().ToDateTime(time);
                }
                catch (FormatException)
                {
                    System.Console.WriteLine($"The entered value doesn't fit for a pattern. Try again");
                    valueIsValid = false;
                }
            }

            return result;
        }

        public static DateOnly CaptureDate()
        {
            DateOnly date = new DateOnly();
            bool exceptionIsCaught = true;

            while (exceptionIsCaught)
            {
                exceptionIsCaught = false;

                try
                {
                    System.Console.Write("Please, enter the date: ");
                    DateOnly result = DateOnly.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    System.Console.WriteLine("The entered value doesn't fit for a pattern. Try again");
                    exceptionIsCaught = true;
                }
            }

            return date;
        }

        public static void CaptureDatesForEvents(List<Event> activities)
        {
            foreach (Event activity in activities)
            {
                System.Console.WriteLine("Enter the date for the nest event:");

                if (activity is Meeting meeting)
                {
                    System.Console.WriteLine(meeting.ToString());
                }
                else if (activity is Birthday birthday)
                {
                    System.Console.WriteLine(birthday.ToString());
                }
                
                activity.DateAndTime = DateTimeCapturer.CaptureDateAndTime();
                Program.PrintDashLine();
            }
        }

        public static TimeSpan CaptureTimeUpToEvent(Event eventToAssess)
        {
            bool exceptionIsCaught = true;
            TimeSpan timeToEvent = new TimeSpan();

            while (exceptionIsCaught)
            {
                exceptionIsCaught = false;

                try
                {
                    timeToEvent = eventToAssess.GetTimeUpToEvent(DateTimeCapturer.CaptureDateAndTime());
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    System.Console.WriteLine(ex.Message);
                    exceptionIsCaught = true;
                }
            }
            
            return timeToEvent;
        }
    }
}