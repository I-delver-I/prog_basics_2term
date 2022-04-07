using System;
using System.Collections.Generic;
using System.Linq;

namespace Labwork_2
{
    public class Worker : IComparable
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public DateTime HiringDate { get; set; }
        public TimeSpan WorkExperience { get; set; } = TimeSpan.Zero;

        public Worker(string name, string surname, string patronymic, DateTime hiringDate)
        {
            Name = name;
            Surname = surname;
            Patronymic = patronymic;
            HiringDate = hiringDate;
        }

        public Worker() { }

        public static Worker GetWorkerWithHighestExperience(List<Worker> workers) => workers.Min();
        
        public void SetWorkExperience(DateTime currentDate) => WorkExperience = currentDate.Subtract(HiringDate);

        public override string ToString() => $"[Name: { Name }; Surname: { Surname }; Patronymic:" +
            $" { Patronymic }; HiringDate: { HiringDate.Date }; WorkExperience: { WorkExperience.TotalDays }]";

        public override bool Equals(object obj) => (obj is Worker worker) && worker.HiringDate.Equals(HiringDate);

        public int CompareTo(object obj) => (obj is Worker worker) ? HiringDate.CompareTo(worker.HiringDate) : -1;
    }
}
