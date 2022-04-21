using System;
using System.Collections.Generic;

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

        public Worker()
        {
            _workers.Add(this);
        }

        public static Worker GetWorkerWithHighestExperience()
        {
            DateTime theEarliestHiringDate = _workers[0].HiringDate;
            Worker mostExperiencedWorker = _workers[0];

            for (int i = 1; i < _workers.Count; i++)
            {
                if (_workers[i].HiringDate < theEarliestHiringDate)
                {
                    theEarliestHiringDate = _workers[i].HiringDate;
                    mostExperiencedWorker = _workers[i];
                }
            }

            return mostExperiencedWorker;
        }

        public override string ToString() => $"[Name: { Name }; Surname: { Surname }; Patronymic:" +
            $" { Patronymic }; HiringDate: { HiringDate.Date }]";
    }
}
