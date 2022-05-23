using Labwork_5.MainFlow;

namespace Labwork_5
{
    public class Meeting : Event
    {
        public PersonModel PersonToMeet { get; set; } = new PersonModel();
        private string _place;
        public string Place
        {
            get => _place;
            set
            {
                Validator.ValidatePlace(value);
                _place = value; 
            }
        }
        
        public Meeting(DateTime dateAndTime, PersonModel person, string place) : base(dateAndTime)
        {
            PersonToMeet = person;
            Place = place;
        }

        public Meeting()
        {
            
        }

        public override string ToString()
        {
            return $"{base.ToString()}, Person to meet - {PersonToMeet}, Place - {Place}";
        }
    }
}