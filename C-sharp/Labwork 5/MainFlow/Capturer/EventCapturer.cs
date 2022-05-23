namespace Labwork_5.MainFlow.Capturer
{
    public class EventCapturer
    {
        private int _meetingsCount;
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public int MeetingsCount
        {
            get => _meetingsCount;
            set
            {
                Validator.ValidateMeetingsCount(value);
                _meetingsCount = value;
            }
        }

        public EventCapturer(int meetingsCount)
        {
            MeetingsCount = meetingsCount;
        }

        public EventCapturer()
        {
            
        }

        public List<Event> CaptureEvents()
        {
            do
            {
                try
                {
                    MeetingsCount--;
                    ActivityScheduler.AddActivity(CaptureMeeting());

                    if (MeetingsCount == 0)
                    {
                        ActivityScheduler.AddActivity(CaptureBirthday());
                    }
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    System.Console.WriteLine(ex.Message);
                    MeetingsCount++;
                }
            } while (MeetingsCount > 0);

            return ActivityScheduler.GetActivitiesList();
        }

        public int CaptureMaxMeetingsCount()
        {
            bool exceptionIsThrown = true;

            while (exceptionIsThrown)
            {
                System.Console.Write("Please, enter maximal count of meetings per day: ");
                exceptionIsThrown = false;

                try
                {
                    MeetingsCount = int.Parse(Console.ReadLine());
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

            return MeetingsCount;
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
                    CapturePlace(meeting);
                    meeting.DateTime = meeting.DateTime.Add(DateTimeCapturer.CaptureTime().ToTimeSpan());
                    Program.PrintDashLine();
                }
                catch (ArgumentException ex)
                {
                    System.Console.WriteLine(ex.Message);
                    exceptionIsThrown = true;
                }
            }

            return meeting;
        }

        private static Birthday CaptureBirthday()
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
                    CapturePlace(birthday);
                    birthday.DateTime = birthday.DateTime.Add(DateTimeCapturer.CaptureTime().ToTimeSpan());
                    Program.PrintDashLine();
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

        private static string CapturePlace(Event activity)
        {
            string place = default;
            bool exceptionIsThrown = true;

            while (exceptionIsThrown)
            {
                System.Console.Write("Please, enter the place: ");
                exceptionIsThrown = false;

                try
                {
                    if (activity is Birthday birthday)
                    {
                        birthday.CelebrationPlace = place = Console.ReadLine();
                    }
                    else if (activity is Meeting meeting)
                    {
                        meeting.Place = place = Console.ReadLine();
                    }
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