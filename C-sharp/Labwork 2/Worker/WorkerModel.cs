using System;
using System.Collections.Generic;

namespace Labwork_2.Worker
{
    public class WorkerModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public DateTime HiringDate { get; set; }

        public WorkerModel(string name, string surname, string patronymic, DateTime hiringDate)
        {
            Name = name;
            Surname = surname;
            Patronymic = patronymic;
            HiringDate = hiringDate;
        }

        public WorkerModel() {  }

        public override string ToString() => $"[Name: { Name }; Surname: { Surname }; Patronymic:" +
            $" { Patronymic }; HiringDate: { HiringDate.Date }]";
    }
}
