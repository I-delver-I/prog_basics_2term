using Labwork_5.MainFlow.Capturer;

namespace Labwork_5.MainFlow
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Please, enter the concrete date when you are free from chores: ");
            DateOnly concreteDate = DateTimeCapturer.CaptureDate();
            EventCapturer eventCapturer = new EventCapturer();
            eventCapturer.MeetingsCount = eventCapturer.CaptureMaxMeetingsCount();

            List<Event> activities = eventCapturer.CaptureEvents();
            ActivityScheduler.AssignDateToEvents(concreteDate);
            PrintEvents();

            System.Console.WriteLine("The last meeting of the day:");
            Meeting lastMeeting = ActivityScheduler.GetLatestMeeting();
            System.Console.WriteLine(lastMeeting);
            
            Birthday birthday = GetBirthdayFromList(activities);
            System.Console.Write("Period of time between last meeting and birthday: ");
            Console.WriteLine(Event.GetTimeBetweenEvents(birthday,lastMeeting));
        }

        static Birthday GetBirthdayFromList(List<Event> activities)
        {
            return activities.FirstOrDefault(activity => activity is Birthday) as Birthday;
        }

        public static void PrintDashLine()
        {
            System.Console.WriteLine(new string('-', 60));
        }

        static void PrintEvents()
        {
            PrintDashLine();
            System.Console.WriteLine("The captured activities are:");

            foreach (Event activity in ActivityScheduler.GetActivitiesList())
            {
                if (activity is Meeting meeting)
                {
                    System.Console.WriteLine($"{meeting.GetType().Name} - {meeting}");
                }
                else if (activity is Birthday birthday)
                {
                    System.Console.WriteLine($"{birthday.GetType().Name} - {birthday}");
                }
            }

            PrintDashLine();
        }
    }
}
