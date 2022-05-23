using System.Text.RegularExpressions;

namespace Labwork_5.MainFlow
{
    public class Validator
    {
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static void ValidateAge(int age)
        {
            if (age <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(age), 
                    "The age of birthday celebrant musn't be less than 1");
            }
        }

        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static void ValidateMeetingsCount(int meetingsCount)
        {
            if (meetingsCount < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(meetingsCount),
                    "The count of meetings per day can't be less than 0");
            }

            int maxMeetingsCount = 126;

            if (meetingsCount > maxMeetingsCount)
            {
                throw new ArgumentOutOfRangeException(nameof(meetingsCount),
                    "The count of meetings per day can't be "
                    +"more than 126 (at least 10 minutes per meeting and 3 hours for birthday)");
            }
        }

        /// <exception cref="ArgumentException"></exception>
        public static void ValidateName(string name)
        {
            if (!Regex.IsMatch(name, @"^[\p{L}\p{M}' \.\-]+$"))
            {
                throw new ArgumentException("The name is invalid");
            }
        }

        /// <exception cref="ArgumentException"></exception>
        public static void ValidatePlace(string place)
        {
            if (place == string.Empty)
            {
                throw new ArgumentException("The name of place shouldn't be empty");
            }
        }

        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static void ValidateMeetingTime(DateTime meetingDateTime)
        {
            TimeOnly lastAvailableMeetingTime = new TimeOnly(20,50);

            if (TimeOnly.FromDateTime(meetingDateTime) > lastAvailableMeetingTime)
            {
                throw new ArgumentOutOfRangeException(nameof(meetingDateTime),
                    "The time of event shouldn't be bigger than last available (20:50)");
            }
        }

        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static void ValidateBirthdayTime(DateTime birthdayDateTime)
        {
            TimeOnly mandatoryForBirthdayStart = new TimeOnly(21,0);

            if (TimeOnly.FromDateTime(birthdayDateTime) > mandatoryForBirthdayStart)                
            {
                throw new ArgumentOutOfRangeException(nameof(birthdayDateTime),
                    "The mandatory for birthday "
                    + $"celebrating is at 21 o'clock. Curret time is {birthdayDateTime}");
            }
        }

        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static void ValidateEventTime(Event occasion)
        {
            TimeSpan minMeetingDuration = new TimeSpan(0,10,0);

            if (ActivityScheduler.GetActivitiesList().Any(activity => 
                {
                    TimeSpan timeBetweenEvents = Event.GetTimeBetweenEvents(occasion,activity);

                    if (timeBetweenEvents < minMeetingDuration)
                    {
                        return true;
                    }

                    return false;
                }))
            {
                throw new ArgumentOutOfRangeException(nameof(occasion),
                    "The time between events should be at least 10 minutes");
            }
        }
    }
}