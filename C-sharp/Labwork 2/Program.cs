using System;

namespace Labwork_2
{
    static class Program
    {
        static void Main(string[] args)
        {
            DateTime currentDate = new DateTime();

            while (currentDate == default)
            {
                Console.WriteLine("Enter the current date: ");
                try
                {
                    currentDate = Convert.ToDateTime(Console.ReadLine());
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine("Please, enter the data of workers you want to add to the list:\n");
            
            // Adding of workers to the list by matching their fields
            do
            {
                Worker worker = new Worker();
                Console.Write("Name: ");
                worker.Name = Console.ReadLine();
                Console.Write("Surname: ");
                worker.Surname = Console.ReadLine();
                Console.Write("Patronymic: ");
                worker.Patronymic = Console.ReadLine();

                do
                {
                    Console.Write("Hiring Date: ");
                    try
                    {
                        worker.HiringDate = Convert.ToDateTime(Console.ReadLine());
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                } while (worker.HiringDate == default);

                Console.WriteLine("Hit \'Delete\' key to end typing or any other one to continue\n");
            }
            while (Console.ReadKey().Key != ConsoleKey.Delete);

            Console.WriteLine(Environment.NewLine);

            // Print info about the most experienced worker
            Worker mostExperiencedWorker = Worker.GetWorkerWithHighestExperience();
            const int CountOfDaysInMonth = 30;
            const int CountOfDaysInYear = 365;
            int workerExperienceInDays = (currentDate - mostExperiencedWorker.HiringDate).Days;
            int partOfExperienceInDays = workerExperienceInDays % CountOfDaysInYear % CountOfDaysInMonth;
            int partOfExperienceInMonths = workerExperienceInDays % CountOfDaysInYear / CountOfDaysInMonth;
            int partOfExperienceInYears = workerExperienceInDays / CountOfDaysInYear;

            if (partOfExperienceInMonths > 0 || partOfExperienceInYears > 0 || partOfExperienceInDays > 0)
            {
                Console.WriteLine($"The worker { mostExperiencedWorker } has the highest experience: " +
                $"{ partOfExperienceInYears } years, { partOfExperienceInMonths } months and" +
                $" { partOfExperienceInDays } days");
            }
            else
            {
                Console.WriteLine("There is no worker having some experience at work");
            }
        }
    }
}
