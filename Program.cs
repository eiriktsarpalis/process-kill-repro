using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace ProcessKillTree
{
    class Program
    {
        static void Main(string[] args)
        {
            string currentExePath = Process.GetCurrentProcess().MainModule.FileName;
            int GetChildCount() => Process.GetProcessesByName(Path.GetFileName(currentExePath)).Count(p => p.Id != Process.GetCurrentProcess().Id);

            if (args.Length == 0)
            {
                var firstChild = Process.Start(currentExePath, "1");

                while (GetChildCount() != 2) { } // wait till both child processes are started

                firstChild.Kill(entireProcessTree: true);

                Console.WriteLine($"{GetChildCount()} remained alive.");
            }
            else if (int.TryParse(args[0], out int index))
            {
                if (index == 1) Process.Start(currentExePath, "2"); // the first child starts one more and that's it

                while (true) { } // make sure the child process never quits
            }
        }
    }
}
