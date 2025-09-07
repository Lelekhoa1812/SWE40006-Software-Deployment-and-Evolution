using System;
using System.Windows.Forms;

namespace CalculatorApp
{
    internal static class Program
    {
        /// <summary>
        /// Application entry point
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());  // Launch Form1
        }
    }
}
