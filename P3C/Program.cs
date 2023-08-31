using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P3C
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (AnotherInstanceExists())

            {
                MessageBox.Show("Application is already running !!", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                Application.Run(new Login());
            }
        }
        public static bool AnotherInstanceExists()
        {
            Process currentRunningProcess = Process.GetCurrentProcess();
            Process[] listOfProcs = Process.GetProcessesByName(currentRunningProcess.ProcessName);

            foreach (Process proc in listOfProcs)
            {
                if ((proc.MainModule.FileName == currentRunningProcess.MainModule.FileName) && (proc.Id != currentRunningProcess.Id))
                    return true;
            }
            return false;
        }
    }
}
