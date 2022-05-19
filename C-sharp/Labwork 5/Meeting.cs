namespace Labwork_5
{
    public class Meeting : Event
    {
        public PersonModel PersonToMeet { get; set; } = new PersonModel();
        public string Place { get; set; }

        public Meeting(DateTime dateAndTime, PersonModel person, string place) : base(dateAndTime)
        {
            PersonToMeet = person;
            Place = place;
        }

        public static Meeting GetLastMeeting(List<Event> activities)
        {
            return activities.Where(activity => activity is Meeting).
                MaxBy(activity => activity.DateAndTime) as Meeting;
        }

        public Meeting()
        {
            
        }
    }
}