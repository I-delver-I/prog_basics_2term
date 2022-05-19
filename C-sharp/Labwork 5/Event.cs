using System;

namespace Labwork_5
{
    public abstract class Event
    {
        public DateTime DateAndTime { get; set; }
        
        public Event(DateTime dateAndTime)
        {
            DateAndTime = new DateTime(dateAndTime.Year,dateAndTime.Month,dateAndTime.Day,
                dateAndTime.Hour, dateAndTime.Minute, dateAndTime.Second);
        }

        public Event()
        {
            
        }

        public TimeSpan GetTimeUpToEvent(DateTime currentDateAndTime)
        {
            if (DateAndTime < currentDateAndTime)
            {
                throw new ArgumentOutOfRangeException(nameof(currentDateAndTime), 
                    "The current date musn't be bigger than event's appointment");
            }
            
            return DateAndTime.Subtract(currentDateAndTime);
        }

        public override string ToString()
        {
            return $"Date and Time - {DateAndTime.ToString()}";
        }
    }
}