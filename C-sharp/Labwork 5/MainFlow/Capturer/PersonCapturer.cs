namespace Labwork_5.MainFlow.Capturer
{
    public class PersonCapturer
    {
        private static int CaptureAge()
        {
            int age = default;
            bool exceptionIsThrown = true;

            while (exceptionIsThrown)
            {
                System.Console.Write("Please, enter the celebrant's age: ");
                exceptionIsThrown = false;

                try
                {
                    age = int.Parse(Console.ReadLine());
                    Validator.ValidateAge(age);
                }
                catch (FormatException)
                {
                    System.Console.WriteLine("The entered value isn't a number");
                    exceptionIsThrown = true;
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    System.Console.WriteLine(ex.Message);
                    exceptionIsThrown = true;
                }
            }

            return age;
        }

        public static void CapturePerson(Event activity)
        {
            PersonModel person = new PersonModel();
            bool exceptionIsThrown = true;
            
            while (exceptionIsThrown)
            {
                exceptionIsThrown = false;

                try
                {
                    System.Console.Write("Please, enter the first name: ");
                    person.FirstName = Console.ReadLine();

                    System.Console.Write("Please, enter the second name: ");
                    person.SecondName = Console.ReadLine();

                    System.Console.Write("Please, enter the patronymic: ");
                    person.Patronymic = Console.ReadLine();

                    if (activity is Birthday birthday)
                    {
                        birthday.CelebrantsAge = CaptureAge();
                        birthday.Celebrant = person;
                    }
                    else if (activity is Meeting meeting)
                    {
                        meeting.PersonToMeet = person;
                    }
                }
                catch (ArgumentException ex)
                {
                    System.Console.WriteLine(ex.Message);
                    exceptionIsThrown = true;
                }
            }
        }
    }
}