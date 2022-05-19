using System;
using System.Globalization;
using Labwork_5.MainFlow.Capturer;

namespace Labwork_5.MainFlow
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Please, enter the concrete date when you are free from chores: ");
            DateOnly concreteDate = DateTimeCapturer.CaptureDate();

            EventCapturer eventCapturer = new EventCapturer(EventCapturer.
                CaptureMaxMeetingCount());
            List<Event> activities = eventCapturer.CaptureEvents();
            DateTimeCapturer.CaptureDatesForEvents(activities);

            System.Console.WriteLine("The last meeting of the day:");
            Meeting lastMeeting = Meeting.GetLastMeeting(activities);
            System.Console.WriteLine(lastMeeting);

            System.Console.WriteLine("Time range from last meeting to birthday:");
            TimeSpan timeUpToEvent = DateTimeCapturer.CaptureTimeUpToEvent(lastMeeting);
            PrintTimeUpToEvent(timeUpToEvent);
        }

        static void PrintTimeUpToEvent(TimeSpan timeToEvent)
        {
            System.Console.WriteLine($"Days - {timeToEvent.Days}," 
                + $" Hours - {timeToEvent.Hours}, Minutes - {timeToEvent.Minutes}");
        }

        public static void PrintDashLine()
        {
            System.Console.WriteLine(new string('-', 60));
        }
    }
}
