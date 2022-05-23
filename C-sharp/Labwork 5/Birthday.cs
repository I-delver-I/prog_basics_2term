using Labwork_5.MainFlow;

namespace Labwork_5
{
    public class Birthday : Event
    {
        public PersonModel Celebrant { get; set; } = new PersonModel();
        private string _celebrationPlace;
        /// <exception cref="ArgumentException"></exception>
        public string CelebrationPlace
        {
            get => _celebrationPlace;
            set
            {
                Validator.ValidatePlace(value);
                _celebrationPlace = value; 
            }
        }
        private int _celebrantsAge;
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public int CelebrantsAge
        {
            get => _celebrantsAge;
            set
            {
                Validator.ValidateAge(value);
                _celebrantsAge = value; 
            }
        }
        
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public Birthday(DateTime dateTime, PersonModel celebrant, string celebrationPlace, int celebrantsAge) :
            base(dateTime)
        {
            Celebrant = celebrant;
            CelebrationPlace = celebrationPlace;
            CelebrantsAge = celebrantsAge;
        }
        
        public Birthday()
        {
            
        }

        public override string ToString()
        {
            return $"{base.ToString()}, Celebrant - {Celebrant}, CelebrationPlace - {CelebrationPlace},"
                + $" Celebrant's age - {CelebrantsAge}";
        }
    }
}