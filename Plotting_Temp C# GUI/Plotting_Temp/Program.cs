/*
 *Copyright(C) 2017 ALHASAN ALKHATIB
 *
 * date:   12, 2017
 * Author: ALHASAN ALKHATIB
 * Description: this C# code is written to read a discrete signal from serial port
 * process and plot it
 *
 */
using System;
using System.Windows.Forms;

namespace Plotting_Temp
{
    /// <summary>
    /// Class with program entry point.
    /// </summary>
    internal sealed class Program
    {
        /// <summary>
        /// Program entry point.
        /// </summary>
        [STAThread]
        private static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

    }
}
