using System;
using System.Collections.Generic;
using System.Text;
using Labwork_2.Worker;

namespace Labwork_2.MainFlow
{
    public class DataCapture
    {
        public static DateTime CaptureCurrentDate()
        {
            DateTime currentDate = default;

            do
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
            while (currentDate == default);

            return currentDate;
        }

        public static void CaptureWorkers(DateTime currentDate)
        {
            do
            {
                WorkerModel worker = new WorkerModel();
                Console.Write("Name: ");
                worker.Name = Console.ReadLine();
                Console.Write("Surname: ");
                worker.Surname = Console.ReadLine();
                Console.Write("Patronymic: ");
                worker.Patronymic = Console.ReadLine();
                CaptureHiringDate(worker, currentDate);

                MessageGenerator.RequestForEndOrContinue();
            }
            while (Console.ReadKey().Key != ConsoleKey.Delete);
        }

        public static void CaptureHiringDate(WorkerModel worker, DateTime currentDate)
        {
            do
            {
                Console.Write("Hiring Date: ");
                try
                {
                    DateTime hiringDate = Convert.ToDateTime(Console.ReadLine());

                    if (hiringDate > currentDate)
                    {
                        throw new ArgumentException("The current date should be bigger or equal to the hiring one");
                    }

                    worker.HiringDate = hiringDate;
                    WorkerProcessor.AddWorker(worker);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }

            } while (worker.HiringDate == default);
        }
    }
}
