# Labwork 1.2
	- organize interaction between console and the project
	
	//string path = @"C:\Users\Дима\Desktop\Studying\Labs\II term\prog_basics_2term\C-sharp\Labwork 1.2\files\My console.exe";
            /*ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = @"C:\Users\Дима\Desktop\Studying\Labs\II term\prog_basics_2term\C-sharp\Labwork 1.2\My console.exe";
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            Process process = new Process();
            process.StartInfo = startInfo;
            process.Start();*/

            Process outputProcess = new Process();
            ProcessStartInfo outputInfo = new ProcessStartInfo(@"C:\Users\Дима\Desktop\Studying\Labs\II term\prog_basics_2term\C-sharp\Labwork 1.2\My console.exe");
            outputInfo.UseShellExecute = false;
            outputInfo.RedirectStandardOutput = true;
            outputProcess.StartInfo = outputInfo;
            outputProcess.Start();

            StreamReader reader = outputProcess.StandardOutput;
            string data = reader.ReadLine();
            Console.WriteLine(data);

            outputProcess.WaitForExit();
            outputProcess.Close();

            //consoleControl.StartProcess(processStartInfo);
            //consoleControl.WriteInput("input", Color.White, true);

            //consoleControl.WriteOutput("Hello, world", Color.Transparent);
            //consoleControl.StopProcess();

#