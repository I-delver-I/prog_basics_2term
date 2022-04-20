using System;
using System.Collections.Generic;
using System.Linq;

namespace Labwork_2
{
    public class Worker
    {
        private static List<Worker> _workers = new List<Worker>();

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public DateTime HiringDate { get; set; }

        public Worker(string name, string surname, string patronymic, DateTime hiringDate)
        {
            Name = name;
            Surname = surname;
            Patronymic = patronymic;
            HiringDate = hiringDate;
            _workers.Add(this);
        }

        public Worker(bool addToList)
        {
            if (addToList)
            {
                _workers.Add(this);
            }
        }

        public static Worker GetWorkerWithHighestExperience(DateTime currentDate)
        {
            DateTime theEarliestHiringDate = DateTime.MaxValue;
            Worker mostExperiencedWorker = new Worker(false);

            foreach (var worker in _workers)
            {
                if (worker.HiringDate < theEarliestHiringDate && worker.HiringDate != default)
                {
                    theEarliestHiringDate = worker.HiringDate;
                    mostExperiencedWorker = worker;
                }
            }

            return mostExperiencedWorker;
        }

        public override string ToString() => $"[Name: { Name }; Surname: { Surname }; Patronymic:" +
            $" { Patronymic }; HiringDate: { HiringDate.Date }]";
    }
}
