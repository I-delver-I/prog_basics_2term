namespace Labwork_5
{
    public class Birthday : Event
    {
        public PersonModel Celebrant { get; set; } = new PersonModel();
        public string CelebrationPlace { get; set; }
        public int CelebrantsAge { get; set; }

        public Birthday(DateTime dateAndTime, PersonModel celebrant, string celebrationPlace, int celebrantsAge) :
            base(dateAndTime)
        {
            Celebrant = celebrant;
            CelebrationPlace = celebrationPlace;
            CelebrantsAge = celebrantsAge;
        }
        
        public Birthday()
        {
            
        }
    }
}