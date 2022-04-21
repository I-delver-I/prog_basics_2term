using Labwork_2.Worker;
using System;
using System.Collections.Generic;
using System.Text;

namespace Labwork_2.MainFlow
{
    public class MessageGenerator
    {
        public static void RequestForEndOrContinue()
        {
            Console.WriteLine("Hit \'Delete\' key to end typing or any other one to continue\n");
        }

        public static void RequestForEnteringDataAboutWorkers()
        {
            Console.WriteLine("Please, enter the data of workers you want to add to the list:\n");
        }
    }
}
