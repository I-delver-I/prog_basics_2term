using Labwork_5.MainFlow;

namespace Labwork_5
{
    public class ActivityScheduler
    {
        private static List<Event> s_activities = new List<Event>();

        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static void AddActivity(Event activity)
        {
            Validator.ValidateEventTime(activity);
            s_activities.Add(activity);
        }

        public static List<Event> GetActivitiesList()
        {
            return s_activities;
        }

        public static Meeting GetLatestMeeting()
        {
            return s_activities.Where(activity => activity is Meeting).MaxBy(activity => activity.DateTime) as Meeting;
        }

        public static void AssignDateToEvents(DateOnly date)
        {
            foreach (Event activity in ActivityScheduler.GetActivitiesList())
            {
                if (activity is Meeting meeting)
                {
                    meeting.DateTime = date.ToDateTime(TimeOnly.FromDateTime(meeting.DateTime));
                }
                else if (activity is Birthday birthday)
                {
                    birthday.DateTime = date.ToDateTime(TimeOnly.FromDateTime(birthday.DateTime));
                }
            }
        }
    }
}