using System;
using System.Text.RegularExpressions;

namespace Labwork_5
{
    public class Validator
    {
        public static void ValidateAge(int age)
        {
            if (age <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(age), 
                    "The age of birthday celebrant musn't be less than 1");
            }
        }

        public static void ValidateMeetingsCountPerDay(int meetingsCountPerDay)
        {
            if (meetingsCountPerDay < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(meetingsCountPerDay),
                    "The count of meetings per day can't be less than 0");
            }

            if (meetingsCountPerDay > 126)
            {
                throw new ArgumentOutOfRangeException(nameof(meetingsCountPerDay),
                    "The count of meetings per day can't be "
                    +"more than 126 (at least 10 minutes per meeting and 3 hours for birthday)");
            }
        }

        public static void ValidateName(string name)
        {
            if (!Regex.IsMatch(name, @"^[\p{L}\p{M}' \.\-]+$"))
            {
                throw new ArgumentException("The name is invalid");
            }
        }

        public static void ValidatePlace(string place)
        {
            if (place == "")
            {
                throw new ArgumentException("The name of place shouldn't be empty");
            }
        }

        public static void ValidateBirthdayDateTime(DateTime dateAndTime, List<Event> activities)
        {
            Meeting lastMeeting = Meeting.GetLastMeeting(activities);

            if (dateAndTime < lastMeeting.DateAndTime)
            {
                throw new ArgumentOutOfRangeException("The last meeting's time should be less than birthday's one");
            }
            
            int mandatoryHourForBirthdayBeginning = 21;

            if (dateAndTime.Hour > mandatoryHourForBirthdayBeginning)
            {
                throw new ArgumentOutOfRangeException("The mandatory for birthday "
                    + "celebrating should be at 21 o'clock. Now it isn't");
            }      
        }
    }
}