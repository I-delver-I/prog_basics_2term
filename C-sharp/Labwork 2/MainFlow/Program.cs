using System;
using Labwork_2.Worker;
using System.Collections.Generic;

namespace Labwork_2.MainFlow
{
    static class Program
    {
        static void Main(string[] args)
        {
            DateTime currentDate = DataCapture.CaptureCurrentDate();

            MessageGenerator.RequestForEnteringDataAboutWorkers();

            DataCapture.CaptureWorkers(currentDate);

            Console.WriteLine(Environment.NewLine);

            WorkerProcessor.PrintInfoAboutMostExperiencedWorkers(currentDate);
        }
    }
}
