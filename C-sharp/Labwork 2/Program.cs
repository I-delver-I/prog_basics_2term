using System;
using System.Collections.Generic;
using System.Collections;

namespace Labwork_2
{
    static class Program
    {
        static void Main(string[] args)
        {
            List<Worker> workers = new List<Worker>();
            
            Console.WriteLine("Please, enter the data of worker you want to add to the list:\n");
            
            do
            {
                workers.Add(GetWorker());
                Console.WriteLine("Hit \'Delete\' key to end typing or any other one to continue\n");
            }
            while (Console.ReadKey().Key != ConsoleKey.Delete);

            Console.WriteLine(Environment.NewLine);
            Worker foundWorker = Worker.GetWorkerWithHighestExperience(workers);
            foundWorker.WorkExperience = GetCurrentDate().Subtract(foundWorker.HiringDate);
            
            if (foundWorker.WorkExperience > TimeSpan.Zero)
            {
                Console.WriteLine($"The worker with the highest experience is:\n" +
                $" { foundWorker } who worked for { foundWorker.WorkExperience.Days / 365 } years and { foundWorker.WorkExperience.Days % 365 / 30 } month");
            }
            else
            {
                Console.WriteLine("The list doesn't have workers hired before the current date");
            }
        }

        public static DateTime GetCurrentDate()
        {
            DateTime currentDate = default;
            bool noFormatException = true;

            while (noFormatException)
            {
                noFormatException = true;

                Console.WriteLine("Enter the ending period of worker experience: ");
                try
                {
                    currentDate = Convert.ToDateTime(Console.ReadLine());
                    noFormatException = false;
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return currentDate;
        }

        public static Worker GetWorker()
        {
            Worker worker = new Worker();
            
            Console.Write("Name: ");
            worker.Name = Console.ReadLine();
            Console.Write("Surname: ");
            worker.Surname = Console.ReadLine();
            Console.Write("Patronymic: ");
            worker.Patronymic = Console.ReadLine();
            Console.Write("Hiring Date: ");
            try
            {
                worker.HiringDate = Convert.ToDateTime(Console.ReadLine());
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

            return worker;
        }
    }
}
