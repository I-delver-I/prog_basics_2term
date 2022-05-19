namespace Labwork_5.MainFlow.Capturer
{
    public class EventCapturer
    {
        public int MaxMeetingsCount { get; set; }
        
        public EventCapturer(int maxMeetingsCount)
        {
            MaxMeetingsCount = maxMeetingsCount;
        }

        public List<Event> CaptureEvents()
        {
            List<Event> activities = new List<Event>();
            
            do
            {
                activities.Add(CaptureMeeting());
                MaxMeetingsCount--;

                if (MaxMeetingsCount == 0)
                {
                    activities.Add(CaptureBirthday(activities));
                }
            } while (MaxMeetingsCount > 0);

            return activities;
        }

        public static int CaptureMaxMeetingCount()
        {
            int maxMeetingsCount = default;
            bool exceptionIsThrown = true;

            while (exceptionIsThrown)
            {
                System.Console.Write("Please, enter maximal count of meetings per day: ");
                exceptionIsThrown = false;

                try
                {
                    maxMeetingsCount = int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    System.Console.WriteLine("The entered value isn't a number");
                    exceptionIsThrown = true;
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    System.Console.WriteLine(ex.Message);
                    exceptionIsThrown = true;
                }
            }

            return maxMeetingsCount;
        }

        private static Meeting CaptureMeeting()
        {
            Meeting meeting = new Meeting();
            bool exceptionIsThrown = true;
            
            while (exceptionIsThrown)
            {
                System.Console.WriteLine("You are forming a meeting:");
                exceptionIsThrown = false;

                try
                {
                    System.Console.WriteLine("Please, identificate the person to meet:");
                    PersonCapturer.CapturePerson(meeting);
                    meeting.Place = CapturePlace();
                }
                catch (ArgumentException ex)
                {
                    System.Console.WriteLine(ex.Message);
                    exceptionIsThrown = true;
                }
            }

            return meeting;
        }

        private static Birthday CaptureBirthday(List<Event> activities)
        {
            Birthday birthday = new Birthday();
            bool exceptionIsThrown = true;
            
            while (exceptionIsThrown)
            {
                System.Console.WriteLine("You are forming a birthday:");
                exceptionIsThrown = false;

                try
                {
                    System.Console.WriteLine("Please, identificate the celebrant:");
                    PersonCapturer.CapturePerson(birthday);
                    birthday.CelebrationPlace = CapturePlace();
                    Validator.ValidateBirthdayDateTime(birthday.DateAndTime,activities);
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    System.Console.WriteLine(ex.Message);
                    exceptionIsThrown = true;
                }
                catch (ArgumentException ex)
                {
                    System.Console.WriteLine(ex.Message);
                    exceptionIsThrown = true;
                }
            }

            return birthday;
        }

        private static string CapturePlace()
        {
            string place = default;
            bool exceptionIsThrown = true;

            while (exceptionIsThrown)
            {
                System.Console.Write("Please, enter the place: ");
                exceptionIsThrown = false;

                try
                {
                    place = Console.ReadLine();
                    Validator.ValidatePlace(place);
                }
                catch (ArgumentException ex)
                {
                    System.Console.WriteLine(ex.Message);
                    exceptionIsThrown = true;
                }
            }

            return place;
        }
    }
}