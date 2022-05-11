using System;
using System.Collections.Generic;
using System.Text;

namespace Labwork_2.Worker
{
    public class WorkerProcessor
    {
        private readonly static List<WorkerModel> _workers = new List<WorkerModel>();

        private static List<WorkerModel> GetListOfWorkersWithHighestExperience()
        {
            DateTime theEarliestHiringDate = _workers[0].HiringDate;
            List<WorkerModel> mostExperiencedWorkers = new List<WorkerModel>() { _workers[0] };

            for (int i = 1; i < _workers.Count; i++)
            {
                if (_workers[i].HiringDate <= theEarliestHiringDate)
                {
                    theEarliestHiringDate = _workers[i].HiringDate;
                    mostExperiencedWorkers.Add(_workers[i]);
                }
            }

            return mostExperiencedWorkers;
        }

        public static void PrintInfoAboutMostExperiencedWorkers(DateTime currentDate)
        {
            List<WorkerModel> mostExperiencedWorkers = GetListOfWorkersWithHighestExperience();
            const int CountOfDaysInMonth = 30;
            const int CountOfDaysInYear = 365;

            foreach (var worker in mostExperiencedWorkers)
            {
                int workerExperienceInDays = (currentDate - worker.HiringDate).Days;
                int partOfExperienceInDays = workerExperienceInDays % CountOfDaysInYear % CountOfDaysInMonth;
                int partOfExperienceInMonths = workerExperienceInDays % CountOfDaysInYear / CountOfDaysInMonth;
                int partOfExperienceInYears = workerExperienceInDays / CountOfDaysInYear;

                if (partOfExperienceInMonths > 0 || partOfExperienceInYears > 0 || partOfExperienceInDays > 0)
                {
                    Console.WriteLine($"The worker { worker } has the highest experience: " +
                    $"{ partOfExperienceInYears } years, { partOfExperienceInMonths } months and" +
                    $" { partOfExperienceInDays } days");
                }
                else
                {
                    Console.WriteLine("There is no worker having some experience at work");
                }
            }
        }

        public static void AddWorker(WorkerModel worker)
        {
            _workers.Add(worker);
        }
    }
}
