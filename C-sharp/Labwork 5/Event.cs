using Labwork_5.MainFlow;

namespace Labwork_5
{
    public abstract class Event
    {
        private DateTime _dateTime;
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public DateTime DateTime
        {
            get => _dateTime;
            set
            {
                if (this is Birthday)
                {
                    Validator.ValidateBirthdayTime(value);
                }
                else if (this is Meeting)
                {
                    Validator.ValidateMeetingTime(value);
                }

                _dateTime = value;
            }
        }
        
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public Event(DateTime dateAndTime)
        {
            DateTime = new DateTime(dateAndTime.Year,dateAndTime.Month,dateAndTime.Day,
                dateAndTime.Hour, dateAndTime.Minute, dateAndTime.Second);
        }

        public Event()
        {
            
        }

        public static TimeSpan GetTimeBetweenEvents(Event leftSideEvent, Event rightSideEvent)
        {
            TimeSpan result = leftSideEvent.DateTime.Subtract(rightSideEvent.DateTime);
            
            if (result.Minutes < 0 || result.Hours < 0 )
            {
                result = result.Negate();
            }

            return result;
        }
        
        public override string ToString()
        {
            return $"Date and Time - {DateTime.ToString()}";
        }
    }
}